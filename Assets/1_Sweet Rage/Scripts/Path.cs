namespace SweetRage {
    using UnityEngine;
    using System.Collections.Generic;
#if UNITY_EDITOR
    using UnityEditor;
#endif

    public class Path : MonoBehaviour {
        [Header("Refs")]
        public GameObject pathPiecePrefab;
        public Transform pointsContainer;
        public Vector3ArrayVariable pathPoints;

        [Header("Params")]
        public bool generateMesh;
        public float meshWidth;
        public float meshHeight;
        public bool autoGenerateFakeMesh;

        private MeshFilter mf;
        private MeshRenderer mr;
        private GameObject meshContainer;
        private Vector3[] points;

        public void ConstructFakeMesh () {
            int pointsCount = pointsContainer.childCount;
            points = new Vector3[pointsCount];
            for ( int i = 0; i < pointsCount; i++ ) {
                points[i] = pointsContainer.GetChild( i ).position;
            }

            if ( generateMesh ) {
                if ( meshContainer )
                    DestroyImmediate( meshContainer );
                meshContainer = new GameObject( "Path Mesh Container" );
                meshContainer.transform.SetParent( transform );
                for ( int i = 0; i < points.Length - 1; i++ ) {
                    Vector3 orientationToNext = (points[i+1] -points[i]);
                    GameObject g = Instantiate( pathPiecePrefab, points[i] + orientationToNext/2, Quaternion.LookRotation(orientationToNext.normalized, Vector3.up ));
                    g.transform.localScale = new Vector3( meshWidth, meshHeight, orientationToNext.magnitude + meshWidth );
                    g.transform.SetParent( meshContainer.transform );
                }
            }

            pathPoints.Value = points;
#if UNITY_EDITOR
            EditorUtility.SetDirty( pathPoints );
            AssetDatabase.SaveAssets();
#endif
        }

        public void ConstructMesh () {
            if ( points.Length < 2 )
                return;

            if ( !mf )
                mf = GetComponent<MeshFilter>();
            if ( !mr )
                mr = GetComponent<MeshRenderer>();

            Mesh mesh = new Mesh();
            mesh.name = "Road";
            mesh.Clear();

            List<Vector3> verts = new List<Vector3>();
            List<int> tris = new List<int>();
            List<Vector3> normals = new List<Vector3>();

            for ( int i = 0; i < points.Length; i++ ) {
                if ( i == 0 ) {
                    Vector3 dirToNextPoint = ( points[ i + 1 ] - points[i] ).normalized;
                    Vector3 p = points[i] - dirToNextPoint * meshWidth / 2;
                    Vector3 dirToP = (points[i] - p ).normalized;
                    verts.Add( p - Vector3.Cross( dirToP, Vector3.up ) * meshWidth / 2 );
                    verts.Add( p + Vector3.Cross( dirToP, Vector3.up ) * meshWidth / 2 );
                    normals.Add( Vector3.up );
                    normals.Add( Vector3.up );
                }
                else if ( i == points.Length - 1 ) {
                    Vector3 dirToPrevPoint = ( points[ i - 1 ] - points[i] ).normalized;
                    Vector3 p = points[i] - dirToPrevPoint * meshWidth / 2;
                    Vector3 dirToP = (points[i] - p ).normalized;
                    verts.Add( p - Vector3.Cross( dirToP, Vector3.up ) * meshWidth / 2 );
                    verts.Add( p + Vector3.Cross( dirToP, Vector3.up ) * meshWidth / 2 );
                    normals.Add( Vector3.up );
                    normals.Add( Vector3.up );
                }
                else {
                    Vector3 dirToNextPoint = ( points[ i + 1 ] - points[i] ).normalized;
                    Vector3 dirToPrevPoint = ( points[ i - 1 ] - points[i] ).normalized;
                    verts.Add( points[i] + new Vector3( dirToNextPoint.x * meshWidth / 2, 0, dirToPrevPoint.y * meshWidth / 2 ) );
                    verts.Add( points[i] - new Vector3( dirToNextPoint.x * meshWidth / 2, 0, dirToPrevPoint.y * meshWidth / 2 ) );
                    normals.Add( Vector3.up );
                    normals.Add( Vector3.up );
                }
            }

            for ( int i = 0; i < points.Length - 1; i++ ) {
                tris.Add( i );
                tris.Add( i + 1 );
                tris.Add( i + 2 );

                tris.Add( i + 1 );
                tris.Add( i + 3 );
                tris.Add( i + 2 );
            }

            mesh.SetVertices( verts );
            mesh.SetTriangles( tris, 0 );
            mesh.SetNormals( normals );

            mf.sharedMesh = mesh;
        }

        private void OnDrawGizmos () {
            if ( points == null )
                return;
            for ( int i = 0; i < points.Length; i++ ) {
                Gizmos.DrawSphere( points[i], 1 );
                Vector3 target = points[Mathf.Min( i + 1, points.Length - 1)];
                Gizmos.DrawLine( points[i], target );
            }
        }
    }
}
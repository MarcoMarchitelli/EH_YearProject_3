namespace TotemTD {
    using UnityEngine;

    public class Path : MonoBehaviour {
        [Header("Params")]
        public float meshWidth;
        public float meshHeight;
        public bool autoSetPoints;

        [HideInInspector] public Vector3[] points;

        private MeshFilter mf;
        private MeshRenderer mr;

        public void SetPoints () {
            points = new Vector3[transform.childCount];
            for ( int i = 0; i < points.Length; i++ ) {
                points[i] = transform.GetChild( i ).position;
            }
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

            Vector3[] verts = new Vector3[ points.Length * 2 ];
            int[] tris = new int[ verts.Length * 3 ];

            Vector3 dirToNextPoint = Vector3.zero;
            Vector3 dirToPrevPoint = Vector3.zero;
            for ( int i = 0; i < points.Length; i++ ) {
                dirToNextPoint = ( points[Mathf.Min( i + 1, points.Length - 1 )] - points[i] ).normalized;
                Vector3 p = points[i] - dirToNextPoint * meshWidth / 2;
                Vector3 dirToP = (points[i] - p ).normalized;
                verts[i * 2] = p - Vector3.Cross( dirToP, Vector3.up ) * meshWidth / 2;
                verts[i * 2 + 1] = p + Vector3.Cross( dirToP, Vector3.up ) * meshWidth / 2;
            }

            for ( int i = 0; i < verts.Length -3; i+=3 ) {
                tris[i] = i  + 2;
                tris[i + 1] = i;
                tris[i + 2] = i + 1;

                tris[i + 3] = i + 2;
                tris[i + 4] = i + 1;
                tris[i + 5] = i + 3;
            }

            mesh.vertices = verts;
            mesh.triangles = tris;
            mesh.RecalculateNormals();

            mf.sharedMesh = mesh;
        }

        private void OnDrawGizmos () {
            if ( points == null )
                return;
            for ( int i = 0; i < points.Length; i++ ) {
                Gizmos.DrawSphere( points[i], 1.5f );
                Vector3 target = points[Mathf.Min( i + 1, points.Length - 1)];
                Gizmos.DrawLine( points[i], target );
            }
        }
    }
}
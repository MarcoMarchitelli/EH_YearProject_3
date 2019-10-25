namespace TotemTD {
    using UnityEngine;

    public class Path : MonoBehaviour {
        [Header("Params")]
        public bool autoSetPoints;

        [HideInInspector] public Vector3[] points;

        public void SetPoints () {
            points = new Vector3[transform.childCount];
            for ( int i = 0; i < transform.childCount; i++ ) {
                points[i] = transform.GetChild( i ).position;
            }
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
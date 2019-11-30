using UnityEngine;

public class PathDrawer : MonoBehaviour {
    public Vector3ArrayVariable pathPoints;
    public float radius;
    public Color color;

    private void OnDrawGizmos () {
        Gizmos.color = color;
        for ( int i = 0; i < pathPoints.Value.Length; i++ ) {
            Gizmos.DrawSphere( pathPoints.Value[i], radius );
        }
    }
}
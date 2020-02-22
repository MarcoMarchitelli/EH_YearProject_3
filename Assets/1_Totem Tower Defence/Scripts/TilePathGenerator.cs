using UnityEngine;

public class TilePathGenerator : MonoBehaviour {
    [Header("Data")]
    public Vector3ArrayVariable pathPoints;

    [Header("Tiles")]
    public Transform straight;
    public Transform turn;

    [Header("References")]
    public Transform pathPointContainer;

    private Transform currentPoint, nextPoint, previousPoint;
    private GameObject tilesContainer;

    public void GeneratePath () {
        if ( !tilesContainer ) {
            tilesContainer = new GameObject( "Tiles Container" );
            tilesContainer.transform.SetParent( transform );
        }

        int count = tilesContainer.transform.childCount;
        if ( Application.isPlaying )
            for ( int i = 0; i < count; i++ ) {
                Destroy( tilesContainer.transform.GetChild( i ).gameObject );
            }
        else
            for ( int i = 0; i < count; i++ ) {
                DestroyImmediate( tilesContainer.transform.GetChild( 0 ).gameObject );
            }

        count = pathPointContainer.childCount;
        pathPoints.Value = new Vector3[count];
        for ( int i = 0; i < count; i++ ) {
            currentPoint = transform.GetChild( i );
            nextPoint = i + 1 < count ? pathPointContainer.GetChild( i + 1 ) : null;
            previousPoint = i - 1 >= 0 ? pathPointContainer.GetChild( i - 1 ) : null;

            if ( nextPoint != null && previousPoint != null ) {
                Vector3 dirToPrev = (previousPoint.position - currentPoint.position).normalized;
                Vector3 dirToNext = (nextPoint.position - currentPoint.position).normalized;
                float dot = Vector3.Dot(dirToNext, dirToPrev);
                if ( dot == 1 ) {
                    Instantiate( straight, tilesContainer.transform );
                }
                else if ( dot == 0 ) {
                    Instantiate( turn, tilesContainer.transform );
                }
                else {
                    Debug.LogError( "Some angle between points is not valid!!" );
                    return;
                }
            }
            else {
                Instantiate( turn, tilesContainer.transform );
            }

            pathPoints.Value[i] = currentPoint.position;
        }
    }
}
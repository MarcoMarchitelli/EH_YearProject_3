using System.Collections;
using UnityEngine;

public class MouseFollower : BaseBehaviour {
    public enum FollowMode { PlaneCasting, RayCasting, ScreenSpace }

    [Header("References")]
    public Transform target;

    [Header("Follow Mode")]
    public FollowMode followMode;

    public bool useMainCam;
    public Camera cam;
    public Vector3 positionOffset;
    public Vector3 planeCenter;
    public Vector3 planeNormal;
    public LayerMask castMask;
    public float rayMaxDistance;

    protected override void CustomSetup () {
        if ( useMainCam )
            cam = Camera.main;
    }

    public void Follow ( bool value ) {
        switch ( followMode ) {
            case FollowMode.PlaneCasting:
            if ( value )
                StartCoroutine( PlaneCastingRoutine() );
            else
                StopCoroutine( PlaneCastingRoutine() );
            break;
            case FollowMode.RayCasting:
            if ( value )
                StartCoroutine( RayCastingRoutine() );
            else
                StopCoroutine( RayCastingRoutine() );
            break;
            case FollowMode.ScreenSpace:
            if ( value )
                StartCoroutine( ScreenSpaceRoutine() );
            else
                StopCoroutine( ScreenSpaceRoutine() );
            break;
        }
    }

    IEnumerator ScreenSpaceRoutine () {
        if ( !target )
            yield break;
        while ( true ) {
            target.position = Input.mousePosition;
        }
    }

    IEnumerator RayCastingRoutine () {
        if ( !target )
            yield break;
        while ( true ) {
            Ray r = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if ( Physics.Raycast( r, out hit, rayMaxDistance, castMask ) ) {
                transform.position = hit.point + positionOffset;
            }
        }
    }

    IEnumerator PlaneCastingRoutine () {
        if ( !target )
            yield break;
        while ( true ) {
            Plane p = new Plane(planeNormal, planeCenter);
            Ray r = cam.ScreenPointToRay(Input.mousePosition);
            float distance = 0;
            if ( p.Raycast( r, out distance ) ) {
                Vector3 pos = r.origin + r.direction * distance;
                transform.position = pos + positionOffset;
            }
        }
    }
}
namespace TotemTD {
    using UnityEngine;
    using UnityEngine.Events;
    using System.Collections;
    using Deirin.EB;
    using Deirin.Utilities;

    public class Placeable : BaseBehaviour {
        [Header("Params")]
        public LayerMask placeableMask;
        public LayerMask previewMask;
        public Color placeableColor;
        public Color unplaceableColor;
        public bool setActiveOnAwake;

        [Header("Events")]
        public UnityEvent OnPlacement;
        public UnityEvent OnDeplacement;
        public UnityColorEvent OnPlaceStateChangeColor;

        bool placed, onContainer;
        Camera cam;
        TurretContainer currentTurretContainer;
        Quaternion targetRot;
        Coroutine placementCoroutine;

        bool OnContainer {
            get => onContainer;
            set {
                if ( onContainer != value ) {
                    onContainer = value;
                    if ( onContainer )
                        currentTurretContainer.PreviewPosition( Entity as TurretModule );
                    OnPlaceStateChangeColor.Invoke( onContainer ? placeableColor : unplaceableColor );
                }
            }
        }

        #region Overrides
        public override void OnAwake () {
            cam = Camera.main;
            OnContainer = false;
            if ( setActiveOnAwake )
                Active( true );
        }
        #endregion

        public void Active ( bool value ) {
            if ( value )
                placementCoroutine = StartCoroutine( PlacementRoutine() );
            else
                StopCoroutine( placementCoroutine );
        }

        IEnumerator PlacementRoutine () {
            while ( true ) {
                RayCast();
                if ( placed == false && Input.GetMouseButtonUp( 0 ) )
                    TryPlace();
                else if ( placed == true && Input.GetMouseButtonUp( 1 ) )
                    OnDeplacement.Invoke();
                yield return null;
            }
        }

        private void RayCast () {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if ( Physics.Raycast( ray, out hit, 500f, placeableMask ) ) { //we hit turret container 
                currentTurretContainer = hit.collider.GetComponent<TurretContainer>();
                OnContainer = currentTurretContainer;
            }
            else if ( Physics.Raycast( ray, out hit, 500f, previewMask ) ) {
                currentTurretContainer = null;
                OnContainer = false;
                transform.position = hit.point;
                targetRot = Quaternion.LookRotation( transform.forward, hit.normal );
            }
        }

        private void TryPlace () {
            if ( OnContainer == false )
                return;
            if ( currentTurretContainer.AddModule( Entity as TurretModule ) ) {
                placed = true;
                OnPlacement.Invoke();
            }
        }
    }
}
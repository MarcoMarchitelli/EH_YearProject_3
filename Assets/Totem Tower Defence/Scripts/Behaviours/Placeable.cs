namespace TotemTD {
    using UnityEngine;
    using UnityEngine.Events;
    using System.Collections;
    using Deirin.EB;

    public class Placeable : BaseBehaviour {
        [Header("Params")]
        public LayerMask placeableMask;
        public LayerMask previewMask;
        public Color placeableColor;
        public Color unplaceableColor;

        [Header("Events")]
        public UnityEvent OnPlacement;
        public UnityEvent OnDeplacement;
        public UnityColorEvent OnCurrentCellChange;

        bool placed, onContainer;
        Camera cam;
        TurretContainer currentTurretContainer;
        Quaternion targetRot;

        #region Overrides
        protected override void CustomSetup () {
            cam = Camera.main;
        }

        public override void OnLateUpdate () {
            if ( onContainer == true )
                return;

            Quaternion startRotation = transform.localRotation;
            transform.localRotation = Quaternion.identity;

            transform.localRotation = Quaternion.Slerp( startRotation, targetRot, 1 - Mathf.Exp( -230f * Time.deltaTime ) );
        }
        #endregion

        public void Active ( bool value ) {
            if ( value )
                StartCoroutine( PlacementRoutine() );
            else
                StopCoroutine( PlacementRoutine() );
        }

        IEnumerator PlacementRoutine () {
            while ( true ) {
                RayCast();
                if ( placed == false && Input.GetMouseButtonUp( 0 ) )
                    TryPlace();
                else if ( !placed && Input.GetMouseButtonUp( 1 ) )
                    OnDeplacement.Invoke();
                yield return null;
            }
        }

        private void RayCast () {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if ( Physics.Raycast( ray, out hit, 500f, placeableMask ) ) { //we hit turret container                
                onContainer = hit.collider.TryGetComponent( out currentTurretContainer );
            }
            else if ( Physics.Raycast( ray, out hit, 500f, previewMask ) ) {
                onContainer = false;
                transform.position = hit.point;
                targetRot = Quaternion.LookRotation( transform.forward, hit.normal );
            }
        }

        private void TryPlace () {
            if ( onContainer == false )
                return;
            if ( currentTurretContainer.AddModule( Entity as TurretModule ) ) {
                placed = true;
                OnPlacement.Invoke();
            }
        }
    }

    [System.Serializable]
    public class UnityColorEvent : UnityEvent<Color> { }
}
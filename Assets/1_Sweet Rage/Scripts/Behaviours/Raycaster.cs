namespace SweetRage {
    using System.Collections;
    using UnityEngine;
    using Deirin.EB;
    using Deirin.Utilities;

    public class Raycaster : BaseBehaviour {
        [Header("Params")]
        public LayerMask moduleMask;
        public LayerMask containerMask;
        public float rayLength;

        [Header("Events")]
        public UnityTurretContainerEvent OnContainerEnter;
        public UnityTurretContainerEvent OnContainerExit;
        public UnityTurretModuleEvent OnModuleHit;

        private bool onContainer;
        private Ray ray;
        private RaycastHit hit;
        private Camera cam;
        private TurretContainer turretContainer;

        protected override void CustomSetup () {
            cam = Camera.main;
        }

        public override void OnUpdate () {
            ray = cam.ScreenPointToRay( Input.mousePosition );
            if ( Physics.Raycast( ray, out hit, rayLength, containerMask ) ) {
                if ( onContainer == false ) {
                    turretContainer = hit.collider.GetComponent<TurretContainer>();
                    OnContainerEnter.Invoke( turretContainer );
                    print( turretContainer.name + " enter" );
                    onContainer = true;
                }
            }
            else {
                if ( onContainer == true ) {
                    onContainer = false;
                    OnContainerExit.Invoke( turretContainer );
                    print( turretContainer.name + " exit" );
                }
            }
        }
    }
}
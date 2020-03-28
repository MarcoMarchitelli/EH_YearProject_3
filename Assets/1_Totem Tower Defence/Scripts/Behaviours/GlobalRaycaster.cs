namespace TotemTD {
    using System.Collections;
    using UnityEngine;
    using Deirin.EB;
    using Deirin.Utilities;

    public class GlobalRaycaster : BaseBehaviour {
        [Header("Params")]
        public LayerMask moduleMask;
        public LayerMask containerMask;
        public float rayLength;

        [Header("Events")]
        public UnityTurretContainerEvent OnContainerEnter;
        public UnityTurretContainerEvent OnContainerExit;
        public UnityTurretModuleEvent OnModuleEnter;
        public UnityTurretModuleEvent OnModuleExit;
        public UnityTurretModuleEvent OnModuleDown;
        public UnityTurretModuleEvent OnModuleUp;

        private bool onContainer;
        private bool onModule;
        private Ray ray;
        private RaycastHit hit;
        private Camera cam;
        private TurretContainer turretContainer;
        private TurretModule turretModule;

        protected override void CustomSetup () {
            cam = Camera.main;
        }

        public override void OnUpdate () {
            ray = cam.ScreenPointToRay( Input.mousePosition );

            //casting for containers
            if ( Physics.Raycast( ray, out hit, rayLength, containerMask ) ) {
                if ( onContainer == false ) {
                    turretContainer = hit.collider.GetComponent<TurretContainer>();
                    OnContainerEnter.Invoke( turretContainer );
                    //print( turretContainer.name + " enter" );
                    onContainer = true;
                }
            }
            else {
                if ( onContainer == true ) {
                    onContainer = false;
                    OnContainerExit.Invoke( turretContainer );
                    //print( turretContainer.name + " exit" );
                }
            }

            //casting for modules
            if ( Physics.Raycast( ray, out hit, rayLength, moduleMask ) ) {
                if ( onModule == false ) {
                    turretModule = hit.collider.GetComponentInParent<TurretModule>();
                    OnModuleEnter.Invoke( turretModule );
                    //print( turretModule.name + " enter" );
                    onModule = true;
                }
            }
            else {
                if ( onModule == true ) {
                    onModule = false;
                    OnModuleExit.Invoke( turretModule );
                    //print( turretModule.name + " exit" );
                }
            }

            //mouse input reading for modules
            if ( onModule )
                if ( Input.GetMouseButtonDown( 0 ) )
                    OnModuleDown.Invoke( turretModule );
                else if ( Input.GetMouseButtonUp( 0 ) )
                    OnModuleUp.Invoke( turretModule );
        }
    }
}
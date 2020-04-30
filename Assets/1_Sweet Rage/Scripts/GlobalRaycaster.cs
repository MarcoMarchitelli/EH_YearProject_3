namespace SweetRage {
    using UnityEngine;

    public class GlobalRaycaster : MonoBehaviour {
        [Header("Params")]
        public LayerMask moduleMask;
        public LayerMask containerMask;
        public float rayLength;

        [Header("Events")]
        public UnityTurretContainerEvent OnContainerEnter;
        public UnityTurretContainerEvent OnContainerExit;
        public UnityTurretModuleEvent OnModuleEnter;
        public UnityTurretModuleEvent OnModuleExit;

        private bool onContainer;
        private bool onModule;
        private Ray ray;
        private RaycastHit hit;
        private Camera cam;
        private TurretContainer turretContainer;
        private TurretModule currentModule, tempModule;

        public void Setup () {
            cam = Camera.main;
        }

        public void Update () {
            ray = cam.ScreenPointToRay( Input.mousePosition );

            //casting for containers
            if ( Physics.Raycast( ray, out hit, rayLength, containerMask ) ) {
                if ( onContainer == false ) {
                    if ( hit.collider.TryGetComponent( out turretContainer ) ) {
                        turretContainer = hit.collider.GetComponent<TurretContainer>();
                        OnContainerEnter.Invoke( turretContainer );
                        onContainer = true;
                    }
                }
            }
            else {
                if ( onContainer == true ) {
                    onContainer = false;
                    OnContainerExit.Invoke( turretContainer );
                }
            }

            //casting for modules
            if ( Physics.Raycast( ray, out hit, rayLength, moduleMask ) ) {
                tempModule = hit.collider.GetComponentInParent<TurretModule>();
                if ( tempModule ) {
                    if ( onModule == false || currentModule != tempModule ) {
                        currentModule = tempModule;
                        OnModuleEnter.Invoke( currentModule );
                        onModule = true;
                    }
                }
            }
            else {
                if ( onModule == true ) {
                    onModule = false;
                    OnModuleExit.Invoke( currentModule );
                }
            }
        }
    }
}
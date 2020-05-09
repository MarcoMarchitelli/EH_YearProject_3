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
                //if we hit a module
                if ( tempModule ) {
                    //if we weren't on a module
                    if ( onModule == false ) {
                        //now we are and we tell everyone
                        currentModule = tempModule;
                        OnModuleEnter.Invoke( currentModule );
                        onModule = true;
                    }
                    //if we were on a module AND the module we hit is different
                    else if ( currentModule != tempModule ) {
                        //we exit from the old one
                        OnModuleExit.Invoke( currentModule );
                        //we enter in the new one
                        currentModule = tempModule;
                        OnModuleEnter.Invoke( currentModule );
                        onModule = true;
                    }
                }
            }
            //if we don't hit a module AND we were on one
            else if ( onModule == true ) {
                //we exit from it
                onModule = false;
                OnModuleExit.Invoke( currentModule );
                currentModule = null;
            }
        }
    }
}
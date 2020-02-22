namespace Deirin.EB {
    using System.Collections;
    using UnityEngine;
    using UnityEngine.Events;

    public class Raycaster : BaseBehaviour {
        [Header("Params")]
        public RaycastData[] data;

        private Camera cam;

        protected override void CustomSetup () {
            cam = Camera.main;
        }

        public void StartCasting () {
            StartCoroutine( CastingRoutine() );
        }

        public void StopCasting () {
            StopCoroutine( CastingRoutine() );
        }

        IEnumerator CastingRoutine () {
            while ( true ) {
                for ( int i = 0; i < data.Length; i++ ) {
                    Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                    if ( Physics.Raycast( ray, data[i].rayLength, data[i].mask ) ) {
                        if ( data[i].entered == false ) {
                            data[i].OnEnter.Invoke();
                            data[i].entered = true;
                        }
                    }
                    else if ( data[i].entered == true ) {
                        data[i].OnExit.Invoke();
                        data[i].entered = false;
                    }
                }
            }
        }
    }

    [System.Serializable]
    public class RaycastData {
        public LayerMask mask;
        public float rayLength;
        public bool entered;
        public UnityEvent OnEnter;
        public UnityEvent OnExit;
    }
}
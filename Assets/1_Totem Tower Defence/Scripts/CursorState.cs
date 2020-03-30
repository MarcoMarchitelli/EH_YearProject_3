namespace SweetRage {
    using UnityEngine;
    using UnityEngine.Events;

    public class CursorState : MonoBehaviour {
        public enum State { Free = 0, Grab = 1 }
        public static CursorState Instance;

        [Header("Events")]
        public UnityEvent OnModuleEnter;
        public UnityEvent OnModuleExit;
        public UnityEvent OnModuleDown;

        private State state = State.Free;
        public State CurrentState => state;

        private void Awake () {
            if ( Instance == null )
                Instance = this;
            else
                Destroy( gameObject );
        }

        public void ModuleEnterHandler () {
            if ( state == State.Free )
                OnModuleEnter.Invoke();
        }

        public void ModuleExitHandler () {
            if ( state == State.Free )
                OnModuleExit.Invoke();
        }

        public void ModuleDownHandler () {
            if ( state == State.Free )
                OnModuleDown.Invoke();
        }

        public void ModuleDeselectionHandler () {
            //if ( state == State.Grab )
            //    state = State.Free;
        }

        public void ModuleSelectionHandler () {
            //if ( state == State.Free )
            //    state = State.Grab;
        }
    }
}
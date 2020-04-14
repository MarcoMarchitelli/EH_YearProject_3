namespace SweetRage {
    using UnityEngine;
    using UnityEngine.Events;
    using Deirin.Utilities;

    public class CursorState : MonoBehaviour {
        public enum State { Free = 0, PreGrab = 1, Grab = 2 }

        [Header("Events")]
        public UnityEvent Free;
        public UnityEvent PreGrab;
        public UnityEvent Grab;

        [ReadOnly] public State state = State.Free;

        public void ModuleEnterHandler () {
            if ( state == State.Free ) {
                state = State.PreGrab;
                PreGrab.Invoke();
            }
        }

        public void ModuleExitHandler () {
            if ( state == State.PreGrab ) {
                state = State.Free;
                Free.Invoke();
            }
        }

        public void MouseDownHandler () {
            if ( state == State.PreGrab ) {
                state = State.Grab;
                Grab.Invoke();
            }
        }

        public void MouseUpHandler () {
            if ( state == State.Grab ) {
                state = State.Free;
                Free.Invoke();
            }
        }

        public void ModuleDeselectionHandler () {
            if ( state == State.Grab ) {
                state = State.Free;
                Free.Invoke();
            }
        }

        public void ModuleSelectionHandler () {
            if ( state == State.Free ) {
                state = State.Grab;
                Grab.Invoke();
            }
        }
    }
}
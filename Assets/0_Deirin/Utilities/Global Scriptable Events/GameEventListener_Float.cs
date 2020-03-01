namespace Deirin.Utilities {
    using UnityEngine;
    using UnityEngine.Events;

    public class GameEventListener_Float : MonoBehaviour {
        public GameEvent_Float gameEvent;
        public UnityEvent_Float response;

        private void OnEnable () {
            gameEvent.Subscribe( this );
        }

        private void OnDisable () {
            gameEvent.Unsubscribe( this );
        }

        public void OnInvoke ( float value ) {
            response.Invoke( value );
        }
    }
}
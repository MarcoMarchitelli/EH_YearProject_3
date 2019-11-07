namespace Deirin.Utilities {
    using UnityEngine;
    using UnityEngine.Events;

    public class GameEventListener : MonoBehaviour {
        public GameEvent gameEvent;
        public UnityEvent response;

        private void OnEnable () {
            gameEvent.Subscribe( this );
        }

        private void OnDisable () {
            gameEvent.Unsubscribe( this );
        }

        public void OnInvoke () {
            response.Invoke();
        }
    }
}
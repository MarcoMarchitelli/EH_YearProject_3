namespace SweetRage {
    using UnityEngine;
    using UnityEngine.Events;

    public class LevelObjectGameEventListener : MonoBehaviour {
        public LevelObjectGameEvent gameEvent;
        public UnityEvent_LevelObject response;

        private void OnEnable () {
            gameEvent.Subscribe( this );
        }

        private void OnDisable () {
            gameEvent.Unsubscribe( this );
        }

        public void OnInvoke ( LevelObject ld ) {
            response.Invoke( ld );
        }
    }

    [System.Serializable]
    public class UnityEvent_LevelObject : UnityEvent<LevelObject> {

    }
}
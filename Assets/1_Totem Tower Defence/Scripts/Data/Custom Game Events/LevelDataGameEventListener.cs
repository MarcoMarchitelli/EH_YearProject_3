namespace SweetRage {
    using UnityEngine;
    using UnityEngine.Events;

    public class LevelDataGameEventListener : MonoBehaviour {
        public LevelDataGameEvent gameEvent;
        public UnityEvent_LevelData response;

        private void OnEnable () {
            gameEvent.Subscribe( this );
        }

        private void OnDisable () {
            gameEvent.Unsubscribe( this );
        }

        public void OnInvoke ( LevelData ld ) {
            response.Invoke( ld );
        }
    }

    [System.Serializable]
    public class UnityEvent_LevelData : UnityEvent<LevelData> {

    }
}
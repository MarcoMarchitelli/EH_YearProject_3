namespace SweetRage {
    using UnityEngine;
    using UnityEngine.Events;

    public class LevelEntityGameEventListener : MonoBehaviour {
        public LevelEntityGameEvent gameEvent;
        public UnityEvent_LevelEntity response;

        private void OnEnable () {
            gameEvent.Subscribe( this );
        }

        private void OnDisable () {
            gameEvent.Unsubscribe( this );
        }

        public void OnInvoke ( LevelEntity ld ) {
            response.Invoke( ld );
        }
    }

    [System.Serializable]
    public class UnityEvent_LevelEntity : UnityEvent<LevelEntity> {

    }
}
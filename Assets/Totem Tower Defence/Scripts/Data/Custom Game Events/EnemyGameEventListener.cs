namespace TotemTD {
    using UnityEngine;

    public class EnemyGameEventListener : MonoBehaviour {
        public EnemyGameEvent gameEvent;
        public UnityEnemyEvent response;

        private void OnEnable () {
            gameEvent.Subscribe( this );
        }

        private void OnDisable () {
            gameEvent.Unsubscribe( this );
        }

        public void OnInvoke ( Enemy e ) {
            response.Invoke( e );
        }
    }
}
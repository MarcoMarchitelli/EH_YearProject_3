namespace TotemTD {
    using UnityEngine;

    public class TurretGameEventListener : MonoBehaviour {
        public TurretGameEvent gameEvent;
        public UnityTurretEvent response;

        private void OnEnable () {
            gameEvent.Subscribe( this );
        }

        private void OnDisable () {
            gameEvent.Unsubscribe( this );
        }

        public void OnInvoke ( Turret t ) {
            response.Invoke( t );
        }
    }
}
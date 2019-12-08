namespace TotemTD {
    using UnityEngine;

    public class TurretModuleGameEventListener : MonoBehaviour {
        public TurretModuleGameEvent gameEvent;
        public UnityTurretModuleEvent response;

        private void OnEnable () {
            gameEvent.Subscribe( this );
        }

        private void OnDisable () {
            gameEvent.Unsubscribe( this );
        }

        public void OnInvoke ( TurretModule t ) {
            response.Invoke( t );
        }
    }
}
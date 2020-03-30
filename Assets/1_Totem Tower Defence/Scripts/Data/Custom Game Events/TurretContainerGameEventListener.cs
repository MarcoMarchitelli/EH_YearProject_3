namespace SweetRage {
    using UnityEngine;

    public class TurretContainerGameEventListener : MonoBehaviour {
        public TurretContainerGameEvent gameEvent;
        public UnityTurretContainerEvent response;

        private void OnEnable () {
            gameEvent.Subscribe( this );
        }

        private void OnDisable () {
            gameEvent.Unsubscribe( this );
        }

        public void OnInvoke ( TurretContainer t ) {
            response.Invoke( t );
        }
    }
}
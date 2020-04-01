namespace SweetRage {
    using UnityEngine;

    public class LevelDataGameEventListener_SM : StateMachineBehaviour {
        public bool autoSubscription = false;
        public LevelDataGameEvent gameEvent;
        public UnityEvent_LevelData response;

        public override void OnStateEnter ( Animator animator, AnimatorStateInfo stateInfo, int layerIndex ) {
            if ( !autoSubscription )
                return;
            Subscribe();
        }

        public override void OnStateExit ( Animator animator, AnimatorStateInfo stateInfo, int layerIndex ) {
            if ( !autoSubscription )
                return;
            Unsubscribe();
        }

        private void OnDisable () {
            if ( !autoSubscription )
                return;
            Unsubscribe();
        }

        public void OnInvoke ( LevelData ld ) {
            response.Invoke( ld );
        }

        public void Subscribe () {
            gameEvent.Subscribe( this );
        }

        public void Unsubscribe () {
            gameEvent.Unsubscribe( this );
        }
    }
}
namespace SweetRage {
    using UnityEngine;

    public class LevelDataGameEventListener_SM : StateMachineBehaviour {
        public bool subscribeOnEnter = false;
        public bool unsubscribeOnExit = false;
        public bool unsubscribeOnDisable = false;
        public LevelDataGameEvent gameEvent;
        public UnityEvent_LevelData response;

        public override void OnStateEnter ( Animator animator, AnimatorStateInfo stateInfo, int layerIndex ) {
            if ( !subscribeOnEnter )
                return;
            Subscribe();
        }

        public override void OnStateExit ( Animator animator, AnimatorStateInfo stateInfo, int layerIndex ) {
            if ( !unsubscribeOnExit )
                return;
            Unsubscribe();
        }

        private void OnDisable () {
            if ( !unsubscribeOnDisable )
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
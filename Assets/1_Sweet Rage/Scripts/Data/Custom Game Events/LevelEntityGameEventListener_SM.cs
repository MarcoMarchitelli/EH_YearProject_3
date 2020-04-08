namespace SweetRage {
    using UnityEngine;

    public class LevelEntityGameEventListener_SM : StateMachineBehaviour {
        public bool subscribeOnEnter = false;
        public bool unsubscribeOnExit = false;
        public bool unsubscribeOnDisable = false;
        public LevelEntityGameEvent gameEvent;
        public UnityEvent_LevelEntity response;

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

        public void OnInvoke ( LevelEntity ld ) {
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
namespace Deirin.StateMachine {
    using UnityEngine;

    public abstract class StateBase : StateMachineBehaviour {
        protected IStateMachineData data;

        internal void Setup ( IStateMachineData data ) {
            this.data = data;
            CustomSetup();
        }

        protected virtual void CustomSetup () {

        }

        public virtual void Enter () {

        }

        public virtual void Tick () {

        }

        public virtual void Exit () {

        }

        public override void OnStateEnter ( Animator animator, AnimatorStateInfo stateInfo, int layerIndex ) {
            base.OnStateEnter( animator, stateInfo, layerIndex );
            Enter();
        }

        public override void OnStateUpdate ( Animator animator, AnimatorStateInfo stateInfo, int layerIndex ) {
            base.OnStateUpdate( animator, stateInfo, layerIndex );
            Tick();
        }

        public override void OnStateExit ( Animator animator, AnimatorStateInfo stateInfo, int layerIndex ) {
            base.OnStateExit( animator, stateInfo, layerIndex );
            Exit();
        }
    }
}
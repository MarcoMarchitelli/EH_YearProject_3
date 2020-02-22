namespace Deirin.StateMachine {
    using UnityEngine;

    public abstract class StateMachineBase : MonoBehaviour {
        [Header("Refs")]
        public Animator animator;

        protected IStateMachineData data;

        public void Setup () {
            CustomDataSetup();
            foreach ( var item in animator.GetBehaviours<StateBase>() ) {
                item.Setup( data );
            }
        }

        protected virtual void CustomDataSetup () {

        }
    }
}
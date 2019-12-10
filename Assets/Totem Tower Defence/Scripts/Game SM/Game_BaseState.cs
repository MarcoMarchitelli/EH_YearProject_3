namespace TotemTD {
    using UnityEngine;
    using UnityEngine.Events;
    using Deirin.StateMachine;

    public abstract class Game_BaseState : StateBase {
        [Header("Events")]
        public UnityEvent OnEnter;
        public UnityEvent OnUpdate;
        public UnityEvent OnExit;

        public override void Enter () {
            OnEnter.Invoke();
        }

        public override void Tick () {
            OnUpdate.Invoke();
        }

        public override void Exit () {
            OnExit.Invoke();
        }
    }
}
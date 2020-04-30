namespace SweetRage {
    using UnityEngine;
    using UnityEngine.Events;
    using Deirin.StateMachine;

    public abstract class Game_BaseState : StateBase {
        [Header("Events")]
        public UnityEvent OnEnter;
        public UnityEvent OnExit;

        protected GameData gameData;

        protected override void CustomSetup() {
            gameData = data as GameData;
        }

        public override void Enter () {
            OnEnter.Invoke();
        }

        public override void Exit () {
            OnExit.Invoke();
        }
    }
}
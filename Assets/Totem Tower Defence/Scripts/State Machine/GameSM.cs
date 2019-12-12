namespace TotemTD {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Deirin.StateMachine;

    public class GameSM : StateMachineBase {
        public GameContext context;

        protected override void CustomDataSetup () {
            context.OnNext += Next;
            data = context;
        }

        public void Next () {
            animator.SetTrigger( "Next" );
        }

        public void Previous () {
            animator.SetTrigger( "Previous" );
        }
    }

    [System.Serializable]
    public class GameContext : IStateMachineData {
        public PhaseUI phaseUI;
        public TurretMenu turretMenu;
        public Level level;

        public System.Action OnNext, OnPrevious;
        public void Next () {
            OnNext?.Invoke();
        }
        public void Previous () {
            OnPrevious?.Invoke();
        }
    }
}
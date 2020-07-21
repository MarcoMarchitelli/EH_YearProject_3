namespace SweetRage {
    using Deirin.Utilities;
    using UnityEngine;

    public class Game_Loss : Game_BaseState {
        [Header("Global Events")]
        public GameEvent OnLevelTransitionOutEnd;
        public GameEvent OnRetryClick;

        private bool retry;

        public override void Enter () {
            base.Enter();

            retry = false;

            OnLevelTransitionOutEnd.OnInvoke += LevelTransitionOutHandler;
            OnRetryClick.OnInvoke += RetryClickHandler;
        }

        private void RetryClickHandler () {
            retry = true;
        }

        private void LevelTransitionOutHandler () {
            if ( retry )
                gameData.Retry();
            else
                gameData.GoNext();
        }

        public override void Exit () {
            OnLevelTransitionOutEnd.OnInvoke -= LevelTransitionOutHandler;
        }
    }
}
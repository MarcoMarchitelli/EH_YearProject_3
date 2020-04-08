namespace SweetRage {
    using Deirin.Utilities;
    using UnityEngine;

    public class Game_Loss : Game_BaseState {
        [Header("Global Events")]
        public GameEvent OnLevelEndClick;

        public override void Enter () {
            base.Enter();

            OnLevelEndClick.OnInvoke += LevelEndClickHandler;
        }

        private void LevelEndClickHandler () {
            gameData.GoNext();
        }

        public override void Exit () {
            OnLevelEndClick.OnInvoke -= LevelEndClickHandler;
        }
    }
}
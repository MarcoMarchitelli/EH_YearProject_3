namespace SweetRage {
    using UnityEngine;
    using Deirin.Utilities;

    public class Game_MainMenu : Game_BaseState {
        [Header("Prefabs")]
        public MainMenuUI mainMenuUIPrefab;

        [Header("Global Events")]
        public LevelEntityGameEvent LevelPlayClick;
        public GameEvent OnMainMenuFadeOut;

        public override void Enter () {
            base.Enter();

            LevelPlayClick.OnInvoke += LevelPlayClickHandler;
            OnMainMenuFadeOut.OnInvoke += FadeOutHandler;

            gameData.mainMenuUI = Instantiate( mainMenuUIPrefab );

            //update level UI based on loaded levels
            gameData.mainMenuUI.SetLevelsData( gameData.levelsEntities );
            gameData.mainMenuUI.UpdateUI();
        }

        private void LevelPlayClickHandler ( LevelEntity level ) {
            gameData.currentSelectedLevel = level;
        }

        private void FadeOutHandler () {
            gameData.GoNext();
        }

        public override void Exit () {
            LevelPlayClick.OnInvoke -= LevelPlayClickHandler;
            OnMainMenuFadeOut.OnInvoke -= FadeOutHandler;
        }
    }
}
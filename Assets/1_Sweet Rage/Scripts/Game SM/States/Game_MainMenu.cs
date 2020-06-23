namespace SweetRage {
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using Deirin.Utilities;

    public class Game_MainMenu : Game_BaseState {
        [Header("Prefabs")]
        public MainMenuUI mainMenuUIPrefab;

        [Header("Global Events")]
        public LevelObjectGameEvent OnLevelSelectionClick;
        public GameEvent OnMainMenuFadeOut;

        private LevelObject selectedLevelObject;

        public override void Enter () {
            base.Enter();

            OnLevelSelectionClick.OnInvoke += LevelSelectionClickHandler;
            OnMainMenuFadeOut.OnInvoke += FadeOutHandler;

            gameData.mainMenuUI = Instantiate( mainMenuUIPrefab );

            //update level UI based on loaded levels
            gameData.mainMenuUI.SetLevelsData( gameData.levelObjects );
            gameData.mainMenuUI.UpdateUI();
        }

        private void LevelSelectionClickHandler ( LevelObject level ) {
            selectedLevelObject = level;
        }

        private void FadeOutHandler () {
            SceneManager.LoadScene( "2_Level" );
            SceneManager.sceneLoaded += SceneLoadedHandler;
        }

        private void SceneLoadedHandler ( Scene arg0, LoadSceneMode arg1 ) {
            gameData.currentLevelObject = selectedLevelObject;
            gameData.GoNext();
        }

        public override void Exit () {
            OnLevelSelectionClick.OnInvoke -= LevelSelectionClickHandler;
            OnMainMenuFadeOut.OnInvoke -= FadeOutHandler;
            SceneManager.sceneLoaded -= SceneLoadedHandler;
        }
    }
}
namespace SweetRage {
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using Deirin.Utilities;

    public class Game_MainMenu : Game_BaseState {
        [Header("Prefabs")]
        public MainMenuUI mainMenuUIPrefab;

        [Header("Global Events")]
        public LevelEntityGameEvent LevelPlayClick;
        public GameEvent OnMainMenuFadeOut;

        private LevelEntity selectedLevelPrefab;

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
            selectedLevelPrefab = level;
        }

        private void FadeOutHandler () {
            SceneManager.LoadScene( "2_Level" );
            SceneManager.sceneLoaded += SceneLoadedHandler;
        }

        private void SceneLoadedHandler ( Scene arg0, LoadSceneMode arg1 ) {
            gameData.currentLevel = Instantiate( selectedLevelPrefab.transform.parent ).GetComponentInChildren<LevelEntity>();
            gameData.GoNext();
        }

        public override void Exit () {
            LevelPlayClick.OnInvoke -= LevelPlayClickHandler;
            OnMainMenuFadeOut.OnInvoke -= FadeOutHandler;
            SceneManager.sceneLoaded -= SceneLoadedHandler;
        }
    }
}
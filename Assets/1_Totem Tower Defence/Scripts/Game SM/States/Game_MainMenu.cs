namespace SweetRage {
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class Game_MainMenu : Game_BaseState {
        [Header("Prefabs")]
        public MainMenuUI mainMenuUIPrefab;

        [Header("Global Events")]
        public LevelEntityGameEvent OnLevelButtonClick;

        private LevelEntity selectedLevelPrefab;

        public override void Enter () {
            base.Enter();

            OnLevelButtonClick.OnInvoke += LevelSelectionHandler;

            gameData.mainMenuUI = Instantiate( mainMenuUIPrefab );

            //update level UI based on loaded levels
            gameData.mainMenuUI.SetLevelsData( gameData.levelsEntities );
            gameData.mainMenuUI.UpdateUI();
        }

        private void LevelSelectionHandler ( LevelEntity level ) {
            selectedLevelPrefab = level;
            SceneManager.LoadScene( "2_Level" );
            SceneManager.sceneLoaded += SceneLoadedHandler;
        }

        private void SceneLoadedHandler ( Scene arg0, LoadSceneMode arg1 ) {
            gameData.currentLevel = Instantiate( selectedLevelPrefab.transform.parent ).GetComponentInChildren<LevelEntity>();
            gameData.GoNext();
        }

        public override void Exit () {
            OnLevelButtonClick.OnInvoke -= LevelSelectionHandler;
            SceneManager.sceneLoaded -= SceneLoadedHandler;
        }
    }
}
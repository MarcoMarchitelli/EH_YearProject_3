namespace SweetRage {
    using UnityEngine.SceneManagement;

    public class Game_Load_Level : Game_BaseState {
        public override void Enter () {
            base.Enter();

            //load main menu scene
            SceneManager.LoadScene( "2_Level" );
            SceneManager.sceneLoaded += SceneLoadedHandler;
        }

        private void SceneLoadedHandler ( Scene arg0, LoadSceneMode arg1 ) {
            gameData.currentLevel = Instantiate( gameData.currentSelectedLevel.transform.parent ).GetComponentInChildren<LevelEntity>();
            gameData.GoNext();
        }

        public override void Exit () {
            SceneManager.sceneLoaded -= SceneLoadedHandler;
        }
    }
}
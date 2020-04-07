namespace SweetRage {
    using UnityEngine.SceneManagement;

    public class Game_Load_MainMenu : Game_BaseState {
        public override void Enter () {
            base.Enter();

            //load main menu scene
            SceneManager.LoadScene( "1_MainMenu" );
            SceneManager.sceneLoaded += SceneLoadedHanlder;
        }

        private void SceneLoadedHanlder ( Scene arg0, LoadSceneMode arg1 ) {
            gameData.GoNext();
        }

        public override void Exit () {
            SceneManager.sceneLoaded -= SceneLoadedHanlder;
        }
    }
}
namespace SweetRage {
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class Game_Init : Game_BaseState {
        public override void Enter () {
            base.Enter();

            //load levels
            gameData.levelsData = Resources.LoadAll<LevelData>( "Levels/" );

            //------ audio setup happens in scene ------

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
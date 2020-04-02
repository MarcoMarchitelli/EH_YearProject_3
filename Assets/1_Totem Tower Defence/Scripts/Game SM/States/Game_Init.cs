namespace SweetRage {
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class Game_Init : Game_BaseState {
        public override void Enter () {
            base.Enter();

            //load levels
            GameObject[] levelContainers = Resources.LoadAll<GameObject>( "Levels/" );

            int count = levelContainers.Length;
            gameData.levelsEntities = new LevelEntity[count];
            for ( int i = 0; i < count; i++ ) {
                gameData.levelsEntities[i] = levelContainers[i].GetComponentInChildren<LevelEntity>();
            }

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
namespace SweetRage {
    using System;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class Game_Init : Game_BaseState {
        [Header("Prefabs")]
        public PhaseUI phaseUIPrefab;
        public PlaceTimeUI placeTimeUIPrefab;
        public ModulesMenuUI modulesMenuUIPrefab;

        public override void Enter () {
            base.Enter();

            gameData.phaseUI = Instantiate( phaseUIPrefab );
            gameData.placeTimeUI = Instantiate( placeTimeUIPrefab );
            gameData.modulesMenuUI = Instantiate( modulesMenuUIPrefab );

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
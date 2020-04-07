namespace SweetRage {
    using UnityEngine;

    public class Game_LevelSetup : Game_BaseState {
        [Header("Prefabs")]
        public PhaseUI phaseUIPrefab;
        public PlaceTimeUI placeTimeUIPrefab;
        public ModulesMenuUI modulesMenuUIPrefab;

        public override void Enter () {
            base.Enter();

            //----- HACK ------
            gameData.phaseUI = FindObjectOfType<PhaseUI>();
            gameData.placeTimeUI = FindObjectOfType<PlaceTimeUI>();
            gameData.modulesMenuUI = FindObjectOfType<ModulesMenuUI>();
            //----- HACK ------

            //level instantation and setup
            gameData.currentLevel.Setup();

            //phase UI setup
            gameData.phaseUI.Setup();

            ////HACK
            ////should call an animation or smtn
            //gameData.placeTimeUI.gameObject.SetActive( false );
            ////HACK

            gameData.GoNext();
        }
    }
}
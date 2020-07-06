﻿namespace SweetRage {
    using Deirin.Utilities;
    using UnityEngine;

    public class Game_LevelSetup : Game_BaseState {
        public GameEvent OnLevelTransitionInEnd;

        [Header("Prefabs")]
        public PhaseUI phaseUIPrefab;
        public PlaceTimeUI placeTimeUIPrefab;
        public ModulesMenuUI modulesMenuUIPrefab;
        public GlobalRaycaster globalRaycasterPrefab;

        public override void Enter () {
            base.Enter();

            //----- HACK ------
            gameData.phaseUI = FindObjectOfType<PhaseUI>();
            gameData.placeTimeUI = FindObjectOfType<PlaceTimeUI>();
            gameData.modulesMenuUI = FindObjectOfType<ModulesMenuUI>();
            //----- HACK ------

            //level instantation and setup
            gameData.currentLevel.Setup();

            //global raycaster instantiation and setup
            Instantiate( globalRaycasterPrefab ).Setup();

            //phase UI setup
            gameData.phaseUI.Setup();

            OnLevelTransitionInEnd.OnInvoke += LevelTransitionInEndHandler;
        }

        private void LevelTransitionInEndHandler () => gameData.GoNext();

        public override void Exit () => OnLevelTransitionInEnd.OnInvoke += LevelTransitionInEndHandler;
    }
}
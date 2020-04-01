namespace SweetRage {
    using UnityEngine;

    public class Game_MainMenu : Game_BaseState {
        [Header("Prefabs")]
        public MainMenuUI mainMenuUIPrefab;

        private LevelDataGameEventListener_SM listener;

        public override void Enter () {
            base.Enter();

            //-------------------- HACK: PER ORA LO FETCHO
            listener = gameData.animator.GetBehaviour<LevelDataGameEventListener_SM>();
            listener.response.AddListener( LevelSelectionHandler );
            listener.Subscribe();
            //-------------------- HACK

            gameData.mainMenuUI = Instantiate( mainMenuUIPrefab );

            //update level UI based on loaded levels
            gameData.mainMenuUI.SetLevelsData( gameData.levelsData );
            gameData.mainMenuUI.UpdateUI();
        }

        private void LevelSelectionHandler ( LevelData level ) {
            gameData.currentLevelData = level;
            gameData.GoNext();
        }

        public override void Exit () {
            listener.response.RemoveListener( LevelSelectionHandler );
            listener.Unsubscribe();
        }
    }
}
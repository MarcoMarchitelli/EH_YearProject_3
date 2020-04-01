namespace SweetRage {
    using UnityEngine;

    public class Game_MainMenu : Game_BaseState {
        [Header("Prefabs")]
        public MainMenuUI mainMenuUIPrefab;

        public override void Enter () {
            base.Enter();

            gameData.mainMenuUI = Instantiate( mainMenuUIPrefab );

            //update level UI based on loaded levels
            gameData.mainMenuUI.SetLevelsData( gameData.levelsData );
            gameData.mainMenuUI.UpdateUI();
        }
    }
}
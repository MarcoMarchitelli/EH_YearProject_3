﻿namespace TotemTD {
    public class Game_Setup : Game_BaseState {
        public override void Enter () {
            gameData.phaseUI.Setup();

            //HACK
            gameData.placeTimeUI.gameObject.SetActive( false );
            //HACK

            gameData.turretMenu.Activate( false );

            gameData.GoNext();
        }
    }
}
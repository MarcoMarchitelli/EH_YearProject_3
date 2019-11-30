namespace TotemTD {
    public class Game_Wave : Game_BaseState {
        public override void Enter () {
            //wave phase graphics
            gameData.phaseUI.SetTexts( "WAVE", "INCOMING" );
            gameData.phaseUI.Play( .5f, () =>
                gameData.phaseUI.Rewind(() => { 
                    //close time graphics
                    gameData.placeTimeUI.gameObject.SetActive( false );
                    //deactivate turret menu
                    gameData.turretMenu.Activate( false );
                    gameData.waveManager.StartWave();
                }
                )
            );
        }
    }
}
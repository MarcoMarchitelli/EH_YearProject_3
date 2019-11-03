namespace TotemTD {
    public class Game_Placement : Game_BaseState {
        public override void Enter () {
            //placement phase graphics
            gameData.phaseUI.SetTexts( "PLACEMENT", "PHASE" );
            gameData.phaseUI.Play( () => gameData.phaseUI.Rewind( PhaseUIEndHandler ) );

            gameData.waveManager.OnPlaceTimeEnd.AddListener( gameData.GoNext );
        }

        private void PhaseUIEndHandler () {
            //activate turret menu
            gameData.turretMenu.Activate( true );
            //time graphics
            //gameData.placeTimeUI.Open();
            //HACK
            gameData.placeTimeUI.gameObject.SetActive( true );
            gameData.waveManager.StartWave();
        }

        public override void Exit () {
            gameData.waveManager.OnPlaceTimeEnd.RemoveListener( gameData.GoNext );
        }
    }
}
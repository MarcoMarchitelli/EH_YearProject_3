namespace TotemTD {
    public class Game_Placement : Game_BaseState {
        public override void Enter () {
            //set current wave
            gameData.waveManager.ChangeWave();
            gameData.phaseUI.SetWaveNumber( gameData.waveManager.CurrentWaveIndex );
            //wave placement graphics
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
        }

        public override void Exit () {
            gameData.waveManager.OnPlaceTimeEnd.RemoveListener( gameData.GoNext );
        }
    }
}
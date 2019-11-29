namespace TotemTD {
    public class Game_Setup : Game_BaseState {
        public override void Enter () {
            gameData.phaseUI.Setup();

            //HACK
            gameData.placeTimeUI.gameObject.SetActive( false );
            //HACK

            //gameData.turretMenu.SetTurretsData( gameData.waveManager.waveData.turretModules );
            //gameData.turretMenu.SetTurretModsData( gameData.waveManager.waveData.turretMods );
            gameData.turretMenu.Activate( false );

            gameData.GoNext();
        }
    }
}
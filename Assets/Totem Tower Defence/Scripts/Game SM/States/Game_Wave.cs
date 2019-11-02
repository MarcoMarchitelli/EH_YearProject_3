namespace TotemTD {
    public class Game_Wave : Game_BaseState {
        public override void Enter () {
            //close time graphics
            gameData.placeTimeUI.gameObject.SetActive( false );
            //deactivate turret menu
            gameData.turretMenu.Activate( false );
            //check win/loss or go to next wave
        }
    }
}
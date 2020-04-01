namespace SweetRage {
    public class Game_LevelSetup : Game_BaseState {
        public override void Enter () {
            base.Enter();

            //wave manager setup
            gameData.currentLevelEntity.Setup();

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
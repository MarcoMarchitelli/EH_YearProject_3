namespace TotemTD {
    public class Game_Setup : Game_BaseState {
        public override void Enter () {
            gameData.enemySpawner.StartWaves();
        }
    } 
}
namespace TotemTD {
    using Deirin.StateMachine;

    public abstract class Game_BaseState : StateBase {
        protected GameData gameData;

        protected override void CustomSetup() {
            gameData = data as GameData;
        }
    }
}
namespace SweetRage {
    using UnityEngine;
    using Deirin.StateMachine;

    public class GameSM : StateMachineBase {
        private GameData gameData;

        private void Awake () {
            Setup();
        }

        protected override void CustomDataSetup () {
            gameData = new GameData();
            gameData.Next += Next;
            gameData.Win += Win;
            gameData.Loss += Loss;
            gameData.animator = animator;
            data = gameData;  
        }

        private void Next () {
            animator.SetTrigger( "Next" );
        }

        private void Win () {
            animator.SetTrigger( "Win" );
        }

        private void Loss () {
            animator.SetTrigger( "Loss" );
        }
    }

    [System.Serializable]
    public class GameData : IStateMachineData {
        [HideInInspector] public LevelEntity currentLevel;
        [HideInInspector] public LevelEntity[] levelsEntities;
        [HideInInspector] public PhaseUI phaseUI;
        [HideInInspector] public PlaceTimeUI placeTimeUI;
        [HideInInspector] public ModulesMenuUI modulesMenuUI;
        [HideInInspector] public MainMenuUI mainMenuUI;
        [HideInInspector] public Animator animator;

        public System.Action Next, Win, Loss;

        public void GoNext () {
            Next?.Invoke();
        }

        public void GoWin () {
            Win?.Invoke();
        }

        public void GoLoss () {
            Loss?.Invoke();
        }
    }
}
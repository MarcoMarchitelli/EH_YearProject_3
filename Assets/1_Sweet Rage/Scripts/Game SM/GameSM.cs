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
            gameData.MainMenu += MainMenu;
            gameData.Retry += Retry;

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

        private void MainMenu () {
            animator.SetTrigger( "MainMenu" );
        }

        private void Retry () {
            animator.SetTrigger( "Retry" );
        }
    }

    [System.Serializable]
    public class GameData : IStateMachineData {
        [HideInInspector] public LevelEntity currentLevel;
        [HideInInspector] public LevelEntity currentSelectedLevel;
        [HideInInspector] public LevelEntity[] levelsEntities;
        [HideInInspector] public PhaseUI phaseUI;
        [HideInInspector] public PlaceTimeUI placeTimeUI;
        [HideInInspector] public ModulesMenuUI modulesMenuUI;
        [HideInInspector] public MainMenuUI mainMenuUI;
        [HideInInspector] public Animator animator;

        public System.Action Next, Win, Loss, MainMenu, Retry;

        public void GoNext () {
            Next?.Invoke();
        }

        public void GoWin () {
            Win?.Invoke();
        }

        public void GoLoss () {
            Loss?.Invoke();
        }

        public void GoToMainMenu () {
            MainMenu?.Invoke();
        }

        public void GoRetry () {
            Retry?.Invoke();
        }
    }
}
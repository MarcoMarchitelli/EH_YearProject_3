namespace SweetRage {
    using UnityEngine;
    using Deirin.StateMachine;

    public class GameSM : StateMachineBase {
        [SerializeField] private GameData gameData;

        private void Awake () {
            Setup();
        }

        protected override void CustomDataSetup () {
            gameData = new GameData();

            gameData.Next += Next;
            gameData.Win += Win;
            gameData.Loss += Loss;
            gameData.MainMenu += MainMenu;

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
    }

    [System.Serializable]
    public class LevelObject {
        public GameObject prefab;
        public LevelEntity entity;
    }

    [System.Serializable]
    public class GameData : IStateMachineData {
        [HideInInspector] public LevelObject currentLevelObject;
        [HideInInspector] public LevelObject[] levelObjects;
        [HideInInspector] public PhaseUI phaseUI;
        [HideInInspector] public PlaceTimeUI placeTimeUI;
        [HideInInspector] public ModulesMenuUI modulesMenuUI;
        [HideInInspector] public MainMenuUI mainMenuUI;
        [HideInInspector] public Animator animator;
        [HideInInspector] public SaveData saveData;

        public Transform levelContainer;

        public System.Action Next, Win, Loss, MainMenu;

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
    }
}
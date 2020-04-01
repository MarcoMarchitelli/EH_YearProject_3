namespace SweetRage {
    using UnityEngine;
    using Deirin.StateMachine;

    public class GameSM : StateMachineBase {
        [Header("Data")]
        [SerializeField] GameData gameData = null;

        private void Awake () {
            Setup();
        }

        protected override void CustomDataSetup () {
            gameData.Next += Next;
            gameData.Win += Win;
            gameData.Loss += Loss;
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
        [HideInInspector] public LevelData currentLevelData;
        [HideInInspector] public LevelEntity currentLevelEntity;
        [HideInInspector] public PhaseUI phaseUI;
        [HideInInspector] public PlaceTimeUI placeTimeUI;
        [HideInInspector] public ModulesMenuUI modulesMenuUI;
        [HideInInspector] public LevelData[] levelsData;
        [HideInInspector] public MainMenuUI mainMenuUI;
        public Animator animator;

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
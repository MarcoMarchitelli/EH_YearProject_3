namespace TotemTD {
    using UnityEngine;
    using Deirin.StateMachine;

    public class GameSM : StateMachineBase {
        [Header("Data")]
        [SerializeField] GameData gameData;

        private void Start () {
            Setup();
        }

        protected override void CustomDataSetup () {
            data = gameData;
        }
    }

    [System.Serializable]
    public class GameData : IStateMachineData {
        public EnemySpawner enemySpawner;
    }
}
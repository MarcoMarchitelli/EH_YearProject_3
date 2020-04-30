namespace SweetRage {
    using Deirin.EB;
    using UnityEngine;
    using UnityEngine.Events;

    [RequireComponent( typeof( Spawner ) )]
    public class SpawnedEnemyThreshold : BaseBehaviour {
        [Header("Params"), Space]
        public int threshold = 0;

        [Header("Events"), Space]
        [Tooltip("Called during OnEnemySpawn")] public UnityEvent onSpawnedEnemyNotExceedThreshold;
        [Tooltip("Called during OnEnemySpawn")] public UnityEvent onSpawnedEnemyExceedThreshold;

        //Property
        public Spawner Spawner { get; private set; }

        protected override void CustomSetup () {
            base.CustomSetup();
            threshold = Mathf.Max( 0, threshold );
            Spawner = GetComponent<Spawner>();
            Spawner.OnEnemySpawn.AddListener( CheckThreshold );
        }

        private void CheckThreshold () {
            if ( threshold <= Spawner.SpawnedEnemy ) {
                //Debug.Log("Exceed Threshold");
                onSpawnedEnemyExceedThreshold?.Invoke();
            }
            else {
                //Debug.Log("Not Exceed Threshold");
                onSpawnedEnemyNotExceedThreshold.Invoke();
            }
        }
    }
}
namespace SweetRage {
    using Deirin.EB;
    using UnityEngine;
    using System.Collections.Generic;
    using UnityEngine.Events;
    using System.Linq;

    [DisallowMultipleComponent]
    public class Spawner : BaseBehaviour, IStoppable {
        [Header("Params")]
        public Enemy enemyPrefab;
        public Vector3ArrayVariable pathPoints;
        public int enemeyToSpawnChunk = 1;

        [Header("Events"), Space]
        public UnityEvent onSpawnerStart;
        public UnityEvent onSpawnerStop;
        public UnityEvent onEnemySpawn;

        //Property
        public int SpawnedEnemy { get; private set; }
        public bool Stopped { get; private set; }
        public IStoppable[] StoppableItems { get; private set; }

        protected override void CustomSetup () {
            base.CustomSetup();

            enemeyToSpawnChunk = Mathf.Max( 1, enemeyToSpawnChunk );
            SpawnedEnemy = 0;
            List<IStoppable> tmpStoppableItems = GetComponentsInChildren<IStoppable>().ToList();
            tmpStoppableItems.Remove( this );
            StoppableItems = tmpStoppableItems.ToArray();
            Stopped = true;
        }

        public void StartSpawner () {
            if ( Stopped ) {
                Stopped = false;
                onSpawnerStart.Invoke();
            }
        }

        public void Stop ( bool callEvent = true ) {
            if ( !Stopped ) {
                Stopped = true;
                StopAllStoppableChilds();
                if ( callEvent )
                    onSpawnerStop.Invoke();
            }
        }

        public void SpawnEnemy () {
            if ( !Stopped && pathPoints ) {
                InstantiateEnemy();
                SpawnedEnemy += enemeyToSpawnChunk;
                onEnemySpawn.Invoke();
            }
        }

        private void InstantiateEnemy () {
            Enemy e = Instantiate(enemyPrefab, pathPoints.Value[0], Quaternion.identity);
            PathPatroller pp;
            if ( e.TryGetBehaviour( out pp ) ) {
                pp.pathPoints = pathPoints;
            }
#if UNITY_EDITOR
            else {
                Debug.LogWarning( "Enemy " + e.name + " does not have a PathPatroller behaviour!" );
            }
#endif
        }

        private void StopAllStoppableChilds () {
            foreach ( var stoppableItem in StoppableItems ) {
                stoppableItem.Stop( false );
            }
        }
    }
}
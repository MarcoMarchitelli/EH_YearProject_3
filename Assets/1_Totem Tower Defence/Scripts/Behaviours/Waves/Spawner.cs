namespace SweetRage {
    using Deirin.EB;
    using UnityEngine;
    using System.Collections.Generic;
    using UnityEngine.Events;
    using System.Linq;

    [DisallowMultipleComponent]
    public class Spawner : BaseBehaviour, IStoppable {
        #region Inspector
        [Header("Params")]
        public Enemy enemyPrefab;
        public Vector3ArrayVariable pathPoints;
        [Min(0)] public int amountToSpawn;

        [Header("Events"), Space]
        public UnityEvent OnSpawnerStart;
        public UnityEvent OnEnemySpawn;
        [SerializeField] private UnityEvent onStop;
        #endregion

        public System.Action OnDutyFullfilled;
        public int SpawnedEnemy { get; private set; }

        private List<Enemy> enemies;
        private bool hasFinished => allSpawned && enemies.Count == 0;
        private bool allSpawned => SpawnedEnemy == amountToSpawn;

        #region IStoppable
        public bool Stopped { get; private set; }
        public IStoppable[] StoppableItems { get; private set; }
        public UnityEvent OnStop { get => onStop; set => onStop = value; }
        public void Stop ( bool callEvent = true ) {
            if ( !Stopped ) {
                Stopped = true;
                StopAllStoppableChilds();
                if ( callEvent )
                    OnStop.Invoke();
            }
        }
        #endregion

        protected override void CustomSetup () {
            base.CustomSetup();

            enemies = new List<Enemy>();
            SpawnedEnemy = 0;
            List<IStoppable> tmpStoppableItems = GetComponentsInChildren<IStoppable>().ToList();
            tmpStoppableItems.Remove( this );
            StoppableItems = tmpStoppableItems.ToArray();
            Stopped = true;
        }

        #region API
        public void StartSpawner () {
            if ( Stopped ) {
                Stopped = false;
                OnSpawnerStart.Invoke();
            }
        }

        public void SpawnEnemy () {
            if ( !Stopped && pathPoints ) {
                InstantiateEnemy();
                OnEnemySpawn.Invoke();
            }
        }

        public void RemoveEnemy ( Enemy e ) {
            if ( enemies == null )
                return;
            if ( enemies.Contains( e ) ) {
                enemies.Remove( e );
                if ( hasFinished )
                    OnDutyFullfilled?.Invoke();
            }
        }
        #endregion

        #region Privates
        private void InstantiateEnemy () {
            Enemy e = Instantiate(enemyPrefab, pathPoints.Value[0], Quaternion.identity);
            enemies.Add( e );
            SpawnedEnemy++;
            PathPatroller pp;
            if ( e.TryGetBehaviour( out pp ) ) {
                pp.pathPoints = pathPoints;
            }
#if UNITY_EDITOR
            else {
                Debug.LogWarning( "Enemy " + e.name + " does not have a PathPatroller behaviour!" );
            }
#endif
            if ( hasFinished )
                OnDutyFullfilled?.Invoke();
        }

        private void StopAllStoppableChilds () {
            foreach ( var stoppableItem in StoppableItems ) {
                stoppableItem.Stop( false );
            }
        }
        #endregion
    }
}
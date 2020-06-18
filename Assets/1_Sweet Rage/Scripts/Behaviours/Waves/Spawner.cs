namespace SweetRage {
    using Deirin.EB;
    using UnityEngine;
    using System.Collections.Generic;
    using UnityEngine.Events;
    using System.Linq;
    using PathCreation;

    [DisallowMultipleComponent]
    public class Spawner : BaseBehaviour, IStoppable {
        #region Inspector
        [Header("Params")]
        public Enemy enemyPrefab;
        public PathCreator pathCreator;
        [Min(0)] public int amountToSpawn;

        [Header("Events"), Space]
        public UnityEvent OnSpawnerStart;
        public UnityEvent OnEnemySpawn;
        public UnityEvent OnAllSpawned;
        [SerializeField] private UnityEvent onStop;
        #endregion

        public System.Action OnDutyFullfilled;
        public int SpawnedEnemy { get; private set; }

        private List<Enemy> enemies;
        private bool allSpawned => SpawnedEnemy >= amountToSpawn;

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
#if UNITY_EDITOR
                print( name + " started spawning" );
#endif
            }
        }

        public void SpawnEnemy () {
            if ( !Stopped && pathCreator != null ) {
                InstantiateEnemy();
            }
        }

        public void RemoveEnemy ( Enemy e ) {
            if ( enemies == null )
                return;
            if ( enemies.Contains( e ) ) {
                enemies.Remove( e );
                CheckDuty();
            }
        }
        #endregion

        #region Privates
        private void InstantiateEnemy () {
            if ( allSpawned )
                return;

            Enemy e = Instantiate(enemyPrefab, pathCreator.path.GetPoint(0), Quaternion.identity);
            e.Setup();
            enemies.Add( e );
            SpawnedEnemy++;
            OnEnemySpawn.Invoke();

            if ( e.pathPatroller ) {
                e.pathPatroller.pathCreator = pathCreator;
                e.pathPatroller.StartPatrol();
            }
#if UNITY_EDITOR
            else {
                Debug.LogWarning( "Enemy " + e.name + " does not have a PathPatroller behaviour!" );
            }
#endif
            CheckDuty();
        }

        private void StopAllStoppableChilds () {
            foreach ( var stoppableItem in StoppableItems ) {
                stoppableItem.Stop( false );
            }
        }

        private void CheckDuty () {
            if ( allSpawned ) {
                OnAllSpawned.Invoke();
#if UNITY_EDITOR
                print( name + " finished spawning" );
#endif
                if ( enemies.Count == 0 ) {
                    OnDutyFullfilled?.Invoke();
#if UNITY_EDITOR
                    print( name + " finished duty" );
#endif
                }
            }
        }
        #endregion
    }
}
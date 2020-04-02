namespace SweetRage {
    using Deirin.EB;
    using UnityEngine;
    using System.Collections.Generic;
    using System.Linq;
    using Deirin.Utilities;
    using UnityEngine.Events;

    [DisallowMultipleComponent]
    public class Wave : BaseBehaviour, IStoppable {
        #region Inspector
        [Min(1)] int index = 0;

        [Header("Parameters")]
        public string preWaveText;
        public string waveText;
        public float placementTime;
        public TurretModule[] modules;

        [Header("Events"), Space]
        public UnityEvent_Int OnWaveStart;
        public UnityEvent_Int OnWaveEnd;
        [SerializeField] private UnityEvent onStop;
        
        #endregion

        #region IStoppable
        public bool Stopped { get; private set; }
        public IStoppable[] StoppableItems { get; private set; }
        public UnityEvent OnStop { get => onStop; set { onStop = value; } }
        public void Stop ( bool callEvent = true ) {
            if ( !Stopped ) {
                Stopped = true;
                StopAllStoppableChilds();
                if ( callEvent )
                    OnStop.Invoke();
            }
        }
        #endregion

        private bool isOver => completedSpawnerCount == spawners.Length;
        private Spawner[] spawners;
        private int completedSpawnerCount;

        protected override void CustomSetup () {
            base.CustomSetup();

            completedSpawnerCount = 0;
            spawners = GetComponentsInChildren<Spawner>();
            foreach ( var spawner in spawners ) {
                spawner.OnDutyFullfilled += SpawnerDutyHandler;
            }

            List<IStoppable> tmpStoppableItems = GetComponentsInChildren<IStoppable>().ToList();
            tmpStoppableItems.Remove( this );
            StoppableItems = tmpStoppableItems.ToArray();
            Stopped = true;
        }

        public void StartWave () {
            if ( Stopped ) {
                Stopped = false;
                OnWaveStart?.Invoke( index );
#if UNITY_EDITOR
                print( name + " started" );
#endif
            }
        }

        private void StopAllStoppableChilds () {
            foreach ( var stoppableItem in StoppableItems ) {
                stoppableItem.Stop( false );
            }
        }

        private void SpawnerDutyHandler () {
            completedSpawnerCount++;
            if ( isOver ) {
                OnWaveEnd.Invoke( index );
#if UNITY_EDITOR
                print( name + " ended" );
#endif
            }
        }
    }
}
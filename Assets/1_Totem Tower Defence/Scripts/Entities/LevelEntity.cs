namespace SweetRage {
    using UnityEngine;
    using UnityEngine.Events;
    using Deirin.EB;
    using Deirin.Utilities;
    using System.Collections.Generic;

    public class LevelEntity : BaseEntity {
        [Header("Events")]
        public UnityEvent_Float OnPlaceTimeStart;
        public UnityEvent OnPlaceTimeEnd;

        private int currentWaveIndex;
        private GameObject modulesContainer;
        private Wave[] waves;
        private Wave currentWave;
        public Wave CurrentWave => currentWave;

        protected override void CustomSetup () {
            waves = GetBehaviours<Wave>().ToArray();
            currentWaveIndex = -1;

            modulesContainer = new GameObject( "Turret Modules Container" );
            modulesContainer.transform.SetParent( transform );

            RuntimeLevelData.turretModules = new List<TurretModule>();
        }

        public bool GoToNextWave () {
            currentWaveIndex++;

            if ( currentWaveIndex >= waves.Length ) {
                return false;
            }
            
            currentWave = waves[currentWaveIndex];
            //RuntimeLevelData.turretModules.Clear();
            foreach ( var module in currentWave.modules ) {
                TurretModule t = Instantiate( module, modulesContainer.transform );
                t.Setup();
                t.gameObject.SetActive( false );
                RuntimeLevelData.turretModules.Add( t );
            }

            currentWave.StartPreWave();

            return true;
        }
    }
}
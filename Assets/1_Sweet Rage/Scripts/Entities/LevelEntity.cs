﻿namespace SweetRage {
    using UnityEngine;
    using Deirin.EB;
    using System.Collections.Generic;
    using Deirin.Utilities;

    public class LevelEntity : BaseEntity {
        [Header("Params")]
        public string levelName;
        public Sprite mapSprite;

        [ReadOnly] public LevelState state;
        private float currentScore;
        public float CurrentScore => currentScore;

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

            foreach ( var module in currentWave.modules ) {
                TurretModule t = Instantiate( module, modulesContainer.transform );
                t.Setup();
                t.gameObject.SetActive( false );
                RuntimeLevelData.turretModules.Add( t );
            }

            return true;
        }

        public void SetCurrentScore ( float score ) {            
            currentScore = score.Clamp01();
        }

        public void SaveMaxScore () {
            if ( currentScore > state.maxScore )
                state.maxScore = currentScore;
        }
    }

    [System.Serializable]
    public class LevelState {
        public float maxScore;
        public bool locked;
    }
}
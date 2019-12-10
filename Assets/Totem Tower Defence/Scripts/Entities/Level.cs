namespace TotemTD {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Events;
    using Deirin.Utilities;

    public class Level : MonoBehaviour {
        [Header("Data")]
        public LevelData data;

        [Header("Refs")]
        public Enemy enemyPrefab;
        public Vector3ArrayVariable pathPoints;

        [Header("Events")]
        public UnityFloatEvent OnPlaceTimeStart;
        public UnityEvent OnPlaceTimeEnd;

        private WaveSequence currentSequence;
        private WaveData currentWave;
        private int currentWaveIndex;
        private bool counting;

        public void Setup () {
            currentSequence = data.waveSequences[currentWaveIndex];
            currentWave = currentSequence.waveData;
        }

        public void StartPlaceTime () {
            StartCoroutine( PlaceTimeRoutine() );
        }

        public void StartLevel () {
            StartCoroutine( WaveRoutine( currentWave ) );
        }

        public void SkipPlaceTime () {
            counting = false;
        }

        IEnumerator PlaceTimeRoutine () {
            float timer = 0;
            counting = true;

            OnPlaceTimeStart.Invoke( currentSequence.placementTime );

            while ( counting == true && timer < currentSequence.placementTime ) {
                timer += Time.deltaTime;
                yield return null;
            }

            OnPlaceTimeEnd.Invoke();
        }

        IEnumerator WaveRoutine ( WaveData waveData ) {
            foreach ( var item in waveData.enemySequences ) {
                yield return new WaitForSeconds( item.startTimer );
                for ( int i = 0; i < item.count; i++ ) {
                    Enemy e = Instantiate( enemyPrefab, pathPoints.Value[0], Quaternion.identity );
                    e.data = item.enemyData;
                    e.Setup();
                    if ( i < item.count - 1 )
                        yield return new WaitForSeconds( item.spawnInterval );
                }
                yield return new WaitForSeconds( item.endTimer );
            }
        }
    }
}
namespace TotemTD {
    using System.Collections;
    using UnityEngine;
    using UnityEngine.Events;

    public class WaveManager : MonoBehaviour {
        [Header("Refs")]
        public Enemy enemyPrefab;
        public Path path;
        public TurretMenu turretMenu;

        [Header("Params")]
        public WaveData[] waves;

        [Header("Events")]
        public UnityFloatEvent OnPlaceTimeStart;
        public UnityEvent OnPlaceTimeEnd;

        public int CurrentWaveIndex => currentWaveIndex;

        private int currentWaveIndex;
        private WaveData currentWave;
        private bool counting;

        public void StartWaves () {
            StartCoroutine( SpawnRoutine() );
        }

        public void SkipPlaceTime () {
            counting = false;
        }

        IEnumerator SpawnRoutine () {
            int c = 0;
            float timer = 0;
            counting = true;

            OnPlaceTimeStart.Invoke( currentWave.placeTime );

            while ( counting && timer < currentWave.placeTime ) {
                timer += Time.deltaTime;
                yield return null;
            }

            OnPlaceTimeEnd.Invoke();

            while ( c < currentWave.enemies ) {
                yield return new WaitForSeconds( currentWave.spawnInterval );
                Enemy e = Instantiate( enemyPrefab, path.points[0].position, Quaternion.identity );
                e.Setup( path );
                e.StartFollowingPath();
                c++;
            }

            currentWaveIndex++;

            if ( currentWaveIndex < waves.Length ) {
                ChangeWave();
                StartCoroutine( SpawnRoutine() );
            }
            else {
                //win
            }
        }

        public void ChangeWave () {
            currentWave = waves[currentWaveIndex];
            turretMenu.SetTurretsData( currentWave.turrets );
        }
    }

    [System.Serializable]
    public class UnityFloatEvent : UnityEvent<float> { }
}
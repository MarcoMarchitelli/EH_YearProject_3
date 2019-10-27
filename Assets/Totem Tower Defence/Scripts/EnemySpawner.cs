namespace TotemTD {
    using System.Collections;
    using UnityEngine;

    public class EnemySpawner : MonoBehaviour {
        [Header("Refs")]
        public Enemy enemyPrefab;
        public Path path;

        [Header("Params")]
        public Wave[] waves;
        public float waveInterval;

        private int currentWaveIndex;
        private Wave currentWave;

        public void StartWaves () {
            currentWave = waves[currentWaveIndex];
            StartCoroutine( SpawnRoutine() );
        }

        IEnumerator SpawnRoutine () {
            int c = 0;
            while ( c < currentWave.enemies ) {
                yield return new WaitForSeconds( currentWave.spawnInterval );
                Enemy e = Instantiate( enemyPrefab, path.points[0].position, Quaternion.identity );
                e.Setup( path );
                e.StartFollowingPath();
                c++;
            }
            currentWaveIndex++;
            if ( currentWaveIndex < waves.Length ) {
                yield return new WaitForSeconds( waveInterval );
                StartCoroutine( SpawnRoutine() );
            }
            else {
                //win
            }
        }
    }

    [System.Serializable]
    public class Wave {
        public int enemies;
        public float spawnInterval;
    }
}
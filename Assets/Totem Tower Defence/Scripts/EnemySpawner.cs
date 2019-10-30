namespace TotemTD {
    using System.Collections;
    using UnityEngine;

    public class EnemySpawner : MonoBehaviour {
        [Header("Refs")]
        public Enemy enemyPrefab;
        public Path path;
        public TurretMenu turretMenu;

        [Header("Params")]
        public WaveData[] waves;
        public float waveInterval;

        private int currentWaveIndex;
        private WaveData currentWave;

        public void StartWaves () {
            ChangeWave();
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
                ChangeWave();
                StartCoroutine( SpawnRoutine() );
            }
            else {
                //win
            }
        }

        void ChangeWave () {
            currentWave = waves[currentWaveIndex];
            turretMenu.SetTurrets( currentWave.turrets );
        }
    }
}
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
        public WaveData waveData;

        [Header("Events")]
        public UnityFloatEvent OnPlaceTimeStart;
        public UnityEvent OnPlaceTimeEnd;

        private bool counting;

        public void StartWave () {
            StartCoroutine( WaveRoutine() );
        }

        public void SkipPlaceTime () {
            counting = false;
        }

        IEnumerator WaveRoutine () {
            float timer = 0;
            counting = true;

            OnPlaceTimeStart.Invoke( waveData.placeTime );

            while ( counting && timer < waveData.placeTime ) {
                timer += Time.deltaTime;
                yield return null;
            }

            OnPlaceTimeEnd.Invoke();

            foreach ( var item in waveData.enemies ) {
                Enemy e = Instantiate( enemyPrefab, path.points[0].position, Quaternion.identity );
                e.Setup( item, path );
                e.StartFollowingPath();
                yield return new WaitForSeconds( waveData.spawnInterval );
            }
        }
    }

    [System.Serializable]
    public class UnityFloatEvent : UnityEvent<float> { }
}
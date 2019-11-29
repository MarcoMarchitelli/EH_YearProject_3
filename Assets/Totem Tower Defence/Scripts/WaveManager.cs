namespace TotemTD {
    using System.Collections;
    using UnityEngine;
    using UnityEngine.Events;

    public class WaveManager : MonoBehaviour {
        [Header("Refs")]
        public Enemy enemyPrefab;
        public TurretMenu turretMenu;

        [Header("Params")]
        public WaveData waveData;
        public Vector3ArrayVariable pathPoints;

        [Header("Events")]
        public UnityFloatEvent OnPlaceTimeStart;
        public UnityEvent OnPlaceTimeEnd;

        private bool counting;

        public void StartPlaceTime () {
            StartCoroutine( PlaceTimeRoutine() );
        }

        public void StartWave () {
            StartCoroutine( WaveRoutine() );
        }

        public void SkipPlaceTime () {
            counting = false;
        }

        IEnumerator PlaceTimeRoutine () {
            float timer = 0;
            counting = true;

            OnPlaceTimeStart.Invoke( waveData.placeTime );

            while ( counting && timer < waveData.placeTime ) {
                timer += Time.deltaTime;
                yield return null;
            }

            OnPlaceTimeEnd.Invoke();           
        }

        IEnumerator WaveRoutine () {
            foreach ( var item in waveData.enemies ) {
                Enemy e = Instantiate( enemyPrefab, pathPoints.Value[0], Quaternion.identity );
                yield return new WaitForSeconds( waveData.spawnInterval );
            }
        }
    }

    [System.Serializable]
    public class UnityFloatEvent : UnityEvent<float> { }
}
namespace TotemTD {
    using System.Collections;
    using UnityEngine;
    using UnityEngine.Events;

    public class Shooter : MonoBehaviour {
        [Header("Refs")]
        public Bullet bulletPrefab;
        public BulletData bulletData;
        public Transform spawnPoint;

        [Header("Params")]
        public float fireRate;

        [Header("Events")]
        public UnityEvent OnShoot;

        private bool shooting;

        public void StartShooting () {
            if ( !shooting )
                StartCoroutine( ShootSequence() );
        }

        public void StopShooting () {
            if ( shooting )
                StopAllCoroutines();
        }

        IEnumerator ShootSequence () {
            shooting = true;
            while ( true ) {
                Bullet b = Instantiate( bulletPrefab, spawnPoint.position, Quaternion.LookRotation( spawnPoint.forward ) );
                b.data = bulletData;
                OnShoot.Invoke();
                yield return new WaitForSeconds( 1 / fireRate );
            }
        }
    }
}
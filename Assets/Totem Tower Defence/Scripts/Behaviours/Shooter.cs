namespace TotemTD {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Events;
    using Deirin.EB;

    public class Shooter : BaseBehaviour {
        [Header("Refs")]
        public Projectile projectilePrefab;
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
            if ( shooting ) {
                StopAllCoroutines();
                shooting = false;
            }
        }

        IEnumerator ShootSequence () {
            shooting = true;
            while ( true ) {
                Projectile b = Instantiate( projectilePrefab, spawnPoint.position, Quaternion.LookRotation( spawnPoint.forward ) );
                OnShoot.Invoke();
                yield return new WaitForSeconds( 1f / fireRate );
            }
        }
    }
}
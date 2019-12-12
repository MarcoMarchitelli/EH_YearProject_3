namespace TotemTD {
    using System.Collections;
    using UnityEngine;
    using Deirin.EB;
    using Deirin.Utilities;

    public class Shooter : BaseBehaviour {
        [Header("Refs")]
        public Projectile projectilePrefab;
        public Transform spawnPoint;

        [Header("Params")]
        public ProjectileData projectileData;
        public float fireRate;

        [Header("Events")]
        public UnityProjectileEvent OnShoot;

        private bool shooting;

        public void StartShooting () {
            if ( !shooting )
                StartCoroutine( ShootSequence() );
        }

        public void StopShooting () {
            shooting = false;
        }

        IEnumerator ShootSequence () {
            shooting = true;
            while ( shooting ) {
                Projectile b = Instantiate( projectilePrefab, spawnPoint.position, Quaternion.LookRotation( spawnPoint.forward ) );
                b.Setup( projectileData );
                OnShoot.Invoke( b );
                yield return new WaitForSeconds( 1f / fireRate );
            }
        }
    }
}
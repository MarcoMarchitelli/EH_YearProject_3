namespace TotemTD {
    using System.Collections;
    using System.Collections.Generic;
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

        public List<TurretModData> turretMods = new List<TurretModData>();

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

        public void AddMod( TurretModData mod ) {
            turretMods.Add( mod );
        }

        public void RemoveMod ( TurretModData mod ) {
            turretMods.Remove( mod );
        }

        IEnumerator ShootSequence () {
            shooting = true;
            while ( true ) {
                Bullet b = Instantiate( bulletPrefab, spawnPoint.position, Quaternion.LookRotation( spawnPoint.forward ) );
                b.data = bulletData;
                foreach ( var item in turretMods ) {
                    b.AddMod( item );
                }
                OnShoot.Invoke();
                yield return new WaitForSeconds( 1f / fireRate );
            }
        }
    }
}
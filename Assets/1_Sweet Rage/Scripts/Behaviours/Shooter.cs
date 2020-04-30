namespace SweetRage {
    using System.Collections;
    using UnityEngine;
    using Deirin.EB;
    using Deirin.Utilities;

    public class Shooter : BaseBehaviour {
        [Header("Refs")]
        public Projectile projectilePrefab;
        public Transform spawnPoint;

        [Header("Params")]
        [SerializeField] private float fireRate;

        [Header("Events")]
        public UnityEvent_Entity OnShoot;

        public float FireRate => fireRate;

        private bool shooting;
        private float startFireRate;
        private Coroutine shootRoutine;

        protected override void CustomSetup () {
            startFireRate = fireRate;
        }

        #region API
        public void StartShooting () {
            if ( !shooting )
                shootRoutine = StartCoroutine( "ShootSequence" );
        }

        public void StopShooting () {
            if ( shooting ) {
                StopCoroutine( shootRoutine );
                shooting = false;
#if UNITY_EDITOR
                print( name + " stopped shooting" );
#endif
            }
        }

        public void SetFireRate ( float value ) {
            fireRate = value;
        } 

        public void ResetFireRate () {
            fireRate = startFireRate;
        }
        #endregion

        IEnumerator ShootSequence () {
#if UNITY_EDITOR
            print( name + " started shooting" );
#endif
            shooting = true;
            while ( shooting ) {
                Shoot();
                yield return new WaitForSeconds( 1f / fireRate );
            }
        }

        private void Shoot () {
            Projectile b = Instantiate( projectilePrefab, spawnPoint.position, Quaternion.LookRotation( spawnPoint.forward ) );
            b.shooter = this;
            OnShoot.Invoke( b );
        }
    }
}
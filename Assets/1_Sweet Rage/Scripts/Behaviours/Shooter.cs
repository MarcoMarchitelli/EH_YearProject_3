namespace SweetRage {
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

        private float timer, timeBewteenShots;
        private bool counting, canShoot, shooting;
        private float startFireRate;

        protected override void CustomSetup () {
            startFireRate = fireRate;
            timeBewteenShots = 1f / fireRate;
            timer = timeBewteenShots;
            shooting = false;
            counting = true;
        }

        public override void OnUpdate () {
            if ( counting ) {
                timer += Time.deltaTime;
                if ( timer >= timeBewteenShots ) {
                    canShoot = true;
                    counting = false;
                }
            }

            if ( shooting )
                if ( canShoot ) {
                    Shoot();
                    timer = 0;
                    canShoot = false;
                    counting = true;
                }
        }

        #region API
        public void StartShooting () {
            if ( !shooting ) {
                shooting = true;
#if UNITY_EDITOR
                Debug.Log( name + " started shooting!" );
#endif
            }
        }

        public void StopShooting () {
            if ( shooting ) {
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

        private void Shoot () {
            Projectile b = Instantiate( projectilePrefab, spawnPoint.position, Quaternion.LookRotation( spawnPoint.forward ) );
            b.shooter = this;
            OnShoot.Invoke( b );
        }
    }
}
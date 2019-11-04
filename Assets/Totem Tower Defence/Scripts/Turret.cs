namespace TotemTD {
    using UnityEngine;

    public class Turret : MonoBehaviour {
        [Header("Data")]
        public TurretBaseData data;

        [Header("Refs")]
        public LookAt lookAt;
        public Shooter shooter;
        public EnemyDetector enemyDetector;
        public Transform modDisplaysContainer;

        [Header("Params")]
        public bool setupOnAwake = true;

        public bool freeSlots => currentModIndex < data.maxMods - 1;

        TurretModDisplay[] modDisplays;
        int currentModIndex;

        private void Awake () {
            if ( setupOnAwake )
                Setup();
        }

        public void Setup () {
            lookAt.turnSpeed = data.turnSpeed;
            lookAt.Setup();

            shooter.fireRate = data.fireRate;
            shooter.bulletData = data.bullet;

            enemyDetector.range = data.detectionRange;
            enemyDetector.Setup();

            currentModIndex = 0;
            modDisplays = new TurretModDisplay[data.maxMods];
        }

        public void AddModDisplay ( TurretModDisplay turretModDisplay ) {
            if ( currentModIndex > 0 && currentModIndex < data.maxMods ) {
                modDisplays[currentModIndex] = turretModDisplay;
                currentModIndex++;
            }
            UpdateDisplay();
        }

        public void RemoveModDisplay ( TurretModDisplay turretModDisplay ) {
            if ( currentModIndex > 0 && currentModIndex < data.maxMods ) {
                Destroy( modDisplays[currentModIndex].gameObject );
                modDisplays[currentModIndex] = null;
                currentModIndex--;
            }
            UpdateDisplay();
        }

        private void SubscribeMod ( TurretModData data ) {
            if ( data is BulletMod ) {

            }
            else if ( data is TurretMod ) {

            }
        }

        private void UnubscribeMod ( TurretModData data ) {

        }

        private void UpdateDisplay () {
            for ( int i = 0; i < modDisplaysContainer.childCount; i++ ) {
                Destroy( modDisplaysContainer.GetChild( 0 ).gameObject );
            }
            for ( int i = 0; i < modDisplays.Length; i++ ) {
                TurretModDisplay t = modDisplays[i];
                if ( t ) {
                    t.transform.SetParent( modDisplaysContainer );
                    t.transform.localPosition = new Vector3( i * t.transform.localScale.x, 0, 0 );
                }
            }
        }
    }
}
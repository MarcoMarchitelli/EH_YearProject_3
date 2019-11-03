namespace TotemTD {
    using UnityEngine;

    public class Turret : MonoBehaviour {
        [Header("Data")]
        public TurretBaseData data;

        [Header("Refs")]
        public LookAt lookAt;
        public Shooter shooter;
        public EnemyDetector enemyDetector;

        [Header("Params")]
        public bool setupOnAwake = true;

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
        }
    } 
}
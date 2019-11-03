namespace TotemTD {
    using UnityEngine;

    [CreateAssetMenu()]
    public class TurretBaseData : GameElement {
        public float turnSpeed;
        public BulletData bullet;
        public float detectionRange;
        public float fireRate;
        [Min(0)] public int maxMods;
    }
}
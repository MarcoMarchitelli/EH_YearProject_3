namespace TotemTD {
    using UnityEngine;

    [CreateAssetMenu()]
    public class TurretBaseData : GameElement {
        public Sprite sprite;
        public float turnSpeed;
        public BulletData bullet;
        public float detectionRange;
        public float fireRate;
        [Min(0)] public int maxMods;
    }
}
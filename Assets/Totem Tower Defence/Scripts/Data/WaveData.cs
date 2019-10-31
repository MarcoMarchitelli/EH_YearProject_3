namespace TotemTD {
    using UnityEngine;

    [CreateAssetMenu()]
    public class WaveData : ScriptableObject {
        public float placeTime;
        public int enemies;
        public float spawnInterval;
        public TurretData[] turrets;
    }
}
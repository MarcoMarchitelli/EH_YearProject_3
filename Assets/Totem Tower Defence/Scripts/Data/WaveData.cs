namespace TotemTD {
    using UnityEngine;

    [CreateAssetMenu()]
    public class WaveData : ScriptableObject {
        public int enemies;
        public float spawnInterval;
        public GameObject[] turrets;
    }
}
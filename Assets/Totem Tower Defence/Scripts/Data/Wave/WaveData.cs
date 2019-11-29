namespace TotemTD {
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu]
    public class WaveData : ScriptableObject {
        public float placeTime;
        public float spawnInterval;
        public List<Enemy> enemies;
        public List<TurretModule> turretModules;
    }
}
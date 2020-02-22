namespace TotemTD {
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu]
    public class WaveData : ScriptableObject {
        public float placeTime = 45;
        public float spawnInterval = 1;
        public List<Enemy> enemies;
        public List<TurretModule> turretModules;

        public void Reset () {
            placeTime = 45;
            spawnInterval = 1;
            enemies.Clear();
            turretModules.Clear();
        }
    }
}
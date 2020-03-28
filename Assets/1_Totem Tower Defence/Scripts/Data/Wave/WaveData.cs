namespace TotemTD {
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu]
    public class WaveData : ScriptableObject {
        public float placeTime = 45;
        public float spawnInterval = 1;
        public ModuleGroup[] moduleGroups;
        public List<Enemy> enemies;
        //public List<TurretModule> turretModules;

        public void Reset () {
            placeTime = 45;
            spawnInterval = 1;
            moduleGroups = null;
            enemies.Clear();
            //turretModules.Clear();
        }
    }

    [System.Serializable]
    public class ModuleGroup {
        public TurretModule module;
        [Min(0)]public int quantity;

        public void AddModule () {
            quantity++;
        }

        public void RemoveModule () {
            quantity--;
        }
    }
}
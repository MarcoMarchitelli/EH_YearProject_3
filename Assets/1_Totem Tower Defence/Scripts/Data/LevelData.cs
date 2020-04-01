namespace SweetRage {
    using UnityEngine;

    public class LevelData : ScriptableObject {
        public LevelEntity levelPrefab;
        public WaveInfo[] wavesInfo;
    }

    [System.Serializable]
    public class WaveInfo {
        [Min(0)] public float placementTime;
        [Min(0)] public int spawnerCount;
        public TurretModule[] modules;
    }
}
namespace SweetRage {
    using System.Collections.Generic;
    using UnityEngine;

    public class WaveData : ScriptableObject {
        public float placeTime = 45;
        public List<TurretModule> turretModules;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Totem TD/Level")]
public class LevelData : ScriptableObject {
    public WaveSequence[] waveSequences;
}

[System.Serializable]
public class WaveSequence {
    public float placementTime;
    public WaveData waveData;
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( menuName = "Totem TD/Wave" )]
public class WaveData : ScriptableObject {
    public float duration;
    public float playerHealth;
    public EnemySequence[] enemySequences;
    public TurretModuleData[] turretModules;
}

[System.Serializable]
public class EnemySequence {
    public float startTimer;
    public EnemyData enemyData;
    public int count;
    public float spawnInterval;
    public float endTimer;
}
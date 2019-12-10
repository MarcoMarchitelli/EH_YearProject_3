using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( menuName = "Totem TD/Enemy" )]
public class EnemyData : ScriptableObject {
    public float health;
    public float damage;
    public float speed;
}
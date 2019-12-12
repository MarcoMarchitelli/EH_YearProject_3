using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( menuName = "Totem TD/Turret Modules/Modifier" )]
public class ModifierModuleData : TurretModuleData {
    public ProjectileData projectileData;
    public float fireRate;
    public float turnRate;
}
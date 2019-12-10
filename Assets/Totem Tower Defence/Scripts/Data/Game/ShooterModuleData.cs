using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( menuName = "Totem TD/Turret Modules/Shooter" )]
public class ShooterModuleData : TurretModuleData {
    public ProjectileData projectileData;
    public float fireRate;
    public float turnRate;
}
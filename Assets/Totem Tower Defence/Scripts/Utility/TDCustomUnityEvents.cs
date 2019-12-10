namespace TotemTD {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Events;

    public static class TDCustomUnityEvents {}

    [System.Serializable]
    public class UnityEnemyEvent : UnityEvent<Enemy> { 

    }

    [System.Serializable]
    public class UnityTurretModuleEvent : UnityEvent<TurretModule> {

    }

    [System.Serializable]
    public class UnityTurretContainerEvent : UnityEvent<TurretContainer> { }

    [System.Serializable]
    public class UnityProjectileEvent : UnityEvent<Projectile> { }
}
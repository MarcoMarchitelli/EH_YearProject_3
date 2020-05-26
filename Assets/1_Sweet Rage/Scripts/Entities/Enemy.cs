namespace SweetRage {
    using UnityEngine.Events;
    using Deirin.EB;
    using UnityEngine;

    public class Enemy : BaseEntity {
        [Min(0)] public float endGateDamage = 0;

        [HideInInspector] public PathPatroller pathPatroller;

        protected override void CustomSetup () => pathPatroller = GetBehaviour<PathPatroller>();
    }

    [System.Serializable]
    public class UnityEnemyEvent : UnityEvent<Enemy> { }
}
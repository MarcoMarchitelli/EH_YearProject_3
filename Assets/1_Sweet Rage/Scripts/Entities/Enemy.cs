namespace SweetRage {
    using UnityEngine.Events;
    using Deirin.EB;

    public class Enemy : BaseEntity {
        public PathPatroller pathPatroller;

        protected override void CustomSetup () => pathPatroller = GetBehaviour<PathPatroller>();
    }

    [System.Serializable]
    public class UnityEnemyEvent : UnityEvent<Enemy> { }
}
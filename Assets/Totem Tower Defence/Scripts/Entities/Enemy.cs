namespace TotemTD {
    using UnityEngine.Events;
    using Deirin.EB;

    public class Enemy : BaseEntity {

    }
    [System.Serializable]
    public class UnityEnemyEvent : UnityEvent<Enemy> { }
}
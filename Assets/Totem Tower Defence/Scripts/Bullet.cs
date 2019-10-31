namespace TotemTD {
    using UnityEngine;

    public class Bullet : MonoBehaviour {
        [Header("Data")]
        public BulletData data;

        [Header("Refs")]
        public Mover mover;
        public EnemyDamageDealer enemyDamageDealer;

        public void Setup () {
            mover.speed = data.speed;
            enemyDamageDealer.damage = data.damage;
        }
    } 
}
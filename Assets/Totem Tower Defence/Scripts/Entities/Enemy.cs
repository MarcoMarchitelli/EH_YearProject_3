namespace TotemTD {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Deirin.EB;

    public class Enemy : BaseEntity {
        [Header("Data")]
        public EnemyData data;

        [Header("References")]
        public DamageReceiver damageReceiver;
        public DamageDealer damageDealer;
        public PathPatroller pathPatroller;

        protected override void CustomSetup () {
            damageReceiver.maxLife = data.health;
            damageDealer.damage = data.damage;
            pathPatroller.speed = data.speed;
        }
    }
}
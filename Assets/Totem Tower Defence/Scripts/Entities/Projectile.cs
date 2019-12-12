namespace TotemTD {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Deirin.EB;

    public class Projectile : MonoBehaviour {
        private ProjectileData data;

        [Header("References")]
        public Mover mover;
        public DamageDealer damageDealer;

        public void Setup ( ProjectileData data ) {
            this.data = data;
            mover.speed = data.speed;
            damageDealer.damage = data.damage;
        }
    }
}
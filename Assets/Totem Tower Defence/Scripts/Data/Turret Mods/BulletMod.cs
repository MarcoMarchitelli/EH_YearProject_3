namespace TotemTD {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(menuName = "Turret Mods/Bullet")]
    public class BulletMod : TurretModData {
        public List<BulletModMixin> mixins;

        public void ChangeStats () {
            foreach ( var item in mixins ) {
                item.ChangeStats();
            }
        }

        public void OnSpawn () {
            foreach ( var item in mixins ) {
                item.OnSpawn();
            }
        }

        public virtual void OnEnemyHit ( Enemy enemy ) {
            foreach ( var item in mixins ) {
                item.OnEnemyHit( enemy );
            }
        }

        public virtual void OnBulletDestroy () {
            foreach ( var item in mixins ) {
                item.OnBulletDestroy();
            }
        }
    }
}
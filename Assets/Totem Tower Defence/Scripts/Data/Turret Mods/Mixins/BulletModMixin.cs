namespace TotemTD {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu( menuName = "Turret Mods/Mixin/Bullet" )]
    public abstract class BulletModMixin : ScriptableObject {
        public virtual void ChangeStats () {

        }

        public virtual void OnSpawn () {

        }

        public virtual void OnEnemyHit ( Enemy enemy ) {

        }

        public virtual void OnBulletDestroy () {

        }
    }
}
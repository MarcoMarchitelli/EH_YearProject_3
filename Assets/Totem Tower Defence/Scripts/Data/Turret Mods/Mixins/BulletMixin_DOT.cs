namespace TotemTD {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu( menuName = "Turret Mods/Mixin/Bullet/DOT" )]
    public class BulletMixin_DOT : BulletModMixin {
        public float DOT;
        public float duration;

        public override void OnEnemyHit ( Enemy enemy ) {
            //add DOT status on enemy
        }
    }
}
namespace TotemTD {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu( menuName = "Turret Mods/Mixin/Bullet/Elemental" )]
    public class BulletMixin_Elemental : BulletModMixin {
        public Element element;
        public float duration;

        public override void OnEnemyHit ( Enemy enemy ) {
            //add element status on enemy
        }
    }
}
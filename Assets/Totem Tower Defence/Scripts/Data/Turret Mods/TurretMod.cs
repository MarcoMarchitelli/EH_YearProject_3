namespace TotemTD {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu( menuName = "Turret Mods/Turret" )]
    public class TurretMod : TurretModData {
        public List<TurretModMixin> mixins;

        public void ChangeStats () {
            foreach ( var item in mixins ) {
                item.ChangeStats();
            }
        }

        public void OnShoot () {
            foreach ( var item in mixins ) {
                item.OnShoot();
            }
        }
    }
}
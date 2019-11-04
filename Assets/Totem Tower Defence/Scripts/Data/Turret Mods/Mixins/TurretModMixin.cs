namespace TotemTD {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu( menuName = "Turret Mods/Mixin/Turret" )]
    public abstract class TurretModMixin : ScriptableObject {
        public virtual void ChangeStats () {

        }

        public virtual void OnShoot () {

        }
    }
}
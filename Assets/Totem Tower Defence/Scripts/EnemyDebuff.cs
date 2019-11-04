namespace TotemTD {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public abstract class EnemyDebuff : MonoBehaviour {
        private Enemy targetEnemy;
        public Enemy TargetEnemy {
            get => targetEnemy;
            set {
                if ( targetEnemy != value ) {
                    targetEnemy = value;
                    OnTargetEnemySet();
                }
            }
        }

        protected virtual void OnTargetEnemySet () {

        }
    }
}
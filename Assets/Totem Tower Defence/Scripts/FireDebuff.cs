namespace TotemTD {
    using System.Collections;
    using UnityEngine;

    public class FireDebuff : EnemyDebuff {
        [Header("Stats")]
        public int ticks;
        public float tickInterval;
        public float damagePerTick;
        public Element element;

        int tickCount;

        protected override void OnTargetEnemySet () {
            StopAllCoroutines();
            StartCoroutine( DamageRoutine() );
        }

        IEnumerator DamageRoutine () {
            while ( tickCount < ticks ) {
                TargetEnemy.Damage( damagePerTick );
                yield return new WaitForSeconds( tickInterval );
                tickCount++;
            }
        }
    }
}
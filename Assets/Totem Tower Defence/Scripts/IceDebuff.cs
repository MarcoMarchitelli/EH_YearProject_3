namespace TotemTD {
    using System.Collections;
    using UnityEngine;

    public class IceDebuff : EnemyDebuff {
        [Header("Stats")]
        [Range(0,100)]public float slowPercentage;
        public float duration;
        public Element element;

        protected override void OnTargetEnemySet () {
            StopAllCoroutines();
            StartCoroutine( SlowRoutine() );
        }

        IEnumerator SlowRoutine () {
            TargetEnemy.speed -= TargetEnemy.speed / 100f * slowPercentage;
            yield return new WaitForSeconds( duration );
            TargetEnemy.speed = TargetEnemy.data.speed;
        }
    }
}
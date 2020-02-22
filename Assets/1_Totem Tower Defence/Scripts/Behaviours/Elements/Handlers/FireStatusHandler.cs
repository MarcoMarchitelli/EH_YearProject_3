namespace TotemTD {
    using UnityEngine;
    using System.Collections;
    using Deirin.EB;

    public class FireStatusHandler : ElementStatusHandler {
        [Header("References")]
        public DamageReceiver damageReceiver;

        private Fire fireElement;
        private Coroutine routine;

        protected override void CustomApply () {
            fireElement = element as Fire;
            routine = StartCoroutine( StatusRoutine() );
        }

        protected override void CustomRemove () {
            if ( routine != null )
                StopCoroutine( routine );
        }

        IEnumerator StatusRoutine () {
            float t = 1;
            while ( true ) {
                damageReceiver.Damage( fireElement.DPS );
                yield return new WaitForSeconds( t );
                t += 1;
                if ( t >= fireElement.duration )
                    yield break;
            }
        }
    }
}
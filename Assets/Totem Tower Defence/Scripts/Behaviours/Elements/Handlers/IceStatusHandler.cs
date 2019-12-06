namespace TotemTD {
    using UnityEngine;
    using System.Collections;
    using Deirin.EB;

    public class IceStatusHandler : ElementStatusHandler {
        [Header("References")]
        public PathPatroller pathPatroller;

        private Ice iceElement;
        private Coroutine routine;

        protected override void CustomApply () {
            iceElement = element as Ice;
            routine = StartCoroutine( StatusRoutine() );
        }

        protected override void CustomRemove () {
            if ( routine != null )
                StopCoroutine( routine );
        }

        IEnumerator StatusRoutine () {
            pathPatroller.speed -= pathPatroller.speed * iceElement.slowPercent;
            yield return new WaitForSeconds( iceElement.duration );
        }
    }
}
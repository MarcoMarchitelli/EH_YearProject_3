namespace Deirin.EB {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Interpolator : BaseBehaviour {
        [Header("Parameters")]
        public AnimationCurve curve;
        public float speed;
        public bool setStartPosOnSetup = true;

        private Vector3 targetPosition;
        private Vector3 startPosition;

        protected override void CustomSetup () {
            if ( setStartPosOnSetup )
                startPosition = transform.position;
        }

        public void SetTarget ( Transform target ) {
            targetPosition = target.position;
        }

        public void StartInterpolation () {
            StartCoroutine( Interpolation() );
        }

        public void StopInterpolation () {
            StopCoroutine( Interpolation() );
        }

        IEnumerator Interpolation () {
            float percent = 0;
            while ( percent < 1 ) {
                yield return null;
            }
        }
    }
}
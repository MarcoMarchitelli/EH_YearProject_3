namespace Deirin.EB {
    using System.Collections;
    using UnityEngine;
    using UnityEngine.Events;

    public class Interpolator : BaseBehaviour {
        [Header("Parameters")]
        public AnimationCurve curve;
        public float speed;
        public float curveValueMultiplier = 1;
        public bool setStartPosOnSetup = true;

        [Header("Events")]
        public UnityEvent OnTargetReached;

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
                percent += speed * Time.deltaTime;
                Vector3 linearPos = Vector3.Lerp(startPosition, targetPosition, percent);
                float y = curve.Evaluate( percent ) * curveValueMultiplier;
                linearPos.Set( linearPos.x, linearPos.y + y, linearPos.z );
                transform.position = linearPos;
                yield return null;
            }
            OnTargetReached.Invoke();
        }
    }
}
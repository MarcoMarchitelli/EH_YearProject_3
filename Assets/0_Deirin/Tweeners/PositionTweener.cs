namespace Deirin.Tweeners {
    using UnityEngine;
    using DG.Tweening;

    public class PositionTweener : BaseTweener {
        [Header("Specific Params")]
        public Transform target;
        public Transform targetTransformPosition;
        public Vector3 targetPosition;
        public bool local = true;

        protected override void AssignTween () {
            targetPosition = targetTransformPosition ? targetTransformPosition.position : targetPosition;
            if ( local )
                tween = target.DOLocalMove( targetPosition, duration );
            else
                tween = target.DOMove( targetPosition, duration );
        }
    }
}
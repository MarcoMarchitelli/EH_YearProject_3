namespace Deirin.Tweeners {
    using UnityEngine;
    using DG.Tweening;

    public class PositionTweener : BaseTweener {
        [Header("Specific Params")]
        public Transform target;
        public Vector3 targetPosition;
        public bool local = true;

        protected override void AssignTween () {
            if ( local )
                tween = target.DOLocalMove( targetPosition, duration );
            else
                tween = target.DOMove( targetPosition, duration );
        }
    }
}
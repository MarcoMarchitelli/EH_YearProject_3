namespace Deirin.Tweeners {
    using UnityEngine;
    using DG.Tweening;

    public class RectTransformPositionTweener : BaseTweener {
        [Header("Specific Params")]
        public RectTransform target;
        public RectTransform targetTransformPosition;
        public Vector2 targetAnchoredPosition;
        public bool local = true;

        protected override void AssignTween () {
            targetAnchoredPosition = targetTransformPosition ? targetTransformPosition.anchoredPosition : targetAnchoredPosition;
            if ( local )
                tween = target.DOLocalMove( targetAnchoredPosition, duration );
            else
                tween = target.DOMove( targetAnchoredPosition, duration );
        }
    }
}
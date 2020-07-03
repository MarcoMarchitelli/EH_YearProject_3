namespace Deirin.Tweeners {
    using UnityEngine;
    using DG.Tweening;

    public class RectTransformPositionTweener : BaseTweener {
        [Header("Specific Params")]
        public RectTransform target;
        public RectTransform targetTransformPosition;
        public Vector2 targetAnchoredPosition;

        protected override void AssignTween () {
            targetAnchoredPosition = targetTransformPosition ? targetTransformPosition.anchoredPosition : targetAnchoredPosition;
            tween = target.DOAnchorPos( targetAnchoredPosition, duration );
        }
    }
}
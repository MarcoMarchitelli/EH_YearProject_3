namespace Deirin.Tweeners {
    using UnityEngine;
    using DG.Tweening;

    public class CanvasGroupTweener : BaseTweener {
        [Header("Specific Params")]
        public CanvasGroup target;
        [Range(0,1)] public float targetAlpha;

        protected override void AssignTween () {
            tween = target.DOFade( targetAlpha, duration );
        }
    }
}
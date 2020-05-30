namespace Deirin.Tweeners {
    using UnityEngine;
    using UnityEngine.UI;
    using DG.Tweening;

    public class ImageFillTweener : BaseTweener {
        [Header("Specific Params")]
        public Image target;
        [Range(0,1)] public float targetPercent;

        protected override void AssignTween () {
            tween = target.DOFillAmount( targetPercent, duration );
        }
    }
}
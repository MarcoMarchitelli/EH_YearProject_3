namespace Deirin.Tweeners {
    using UnityEngine;
    using UnityEngine.UI;
    using DG.Tweening;

    public class ImageColorTweener : BaseTweener {
        [Header("Specific Params")]
        public Image target;
        public Color targetColor;

        protected override void AssignTween () {
            tween = target.DOColor( targetColor, duration );
        }
    }
}
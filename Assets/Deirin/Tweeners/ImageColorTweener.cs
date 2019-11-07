namespace Deirin.Tweeners {
    using UnityEngine;
    using UnityEngine.UI;
    using DG.Tweening;

    public class ImageColorTweener : BaseTweener {
        [Header("Specific Params")]
        public Image target;
        public Color targetColor;

        Color startColor;

        public override void BackwardsTween () {
            target.DOColor( startColor, duration ).SetEase( ease ).SetLoops( loops ).onComplete += () => OnTweenerEnd.Invoke();
            OnTweenerRewind.Invoke();
        }

        public override void PlayTween () {
            OnTweenerStart.Invoke();
            startColor = target.color;
            target.DOColor( targetColor, duration ).SetEase( ease ).SetLoops( loops ).onComplete += () => OnTweenerEnd.Invoke();
        }

        public override void StopTween () {
            target.DOKill();
            OnTweenerEnd.Invoke();
        }
    }
}
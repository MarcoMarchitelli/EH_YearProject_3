namespace Deirin.Tweeners {
    using UnityEngine;
    using UnityEngine.UI;
    using DG.Tweening;

    public class ImageColorTweener : BaseTweener {
        [Header("Specific Params")]
        public Image target;
        public Color targetColor;
        public bool resetOnPlay = true;

        Color startColor;

        private void Awake () {
            startColor = target.color;
        }

        public override void BackwardsTween () {
            target.DOKill();
            target.DOColor( startColor, duration ).SetEase( ease ).SetLoops( loops ).onComplete += () => OnTweenerEnd.Invoke();
            OnTweenerRewind.Invoke();
        }

        public override void PlayTween () {
            target.DOKill();
            OnTweenerStart.Invoke();
            if ( resetOnPlay == false )
                startColor = target.color;
            target.DOColor( targetColor, duration ).SetEase( ease ).SetLoops( loops ).onComplete += () => OnTweenerEnd.Invoke();
        }

        public override void StopTween () {
            target.DOKill();
            OnTweenerEnd.Invoke();
        }
    }
}
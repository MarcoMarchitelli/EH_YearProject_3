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

        public override void Rewind () {
            target.DOKill();
            target.DOColor( startColor, duration ).SetEase( ease ).SetLoops( loops ).onComplete += () => OnRewindEnd.Invoke();
            OnRewind.Invoke();
        }

        public override void Play () {
            target.DOKill();
            OnPlay.Invoke();
            if ( resetOnPlay == false )
                startColor = target.color;
            target.DOColor( targetColor, duration ).SetEase( ease ).SetLoops( loops ).onComplete += () => OnPlayEnd.Invoke();
        }

        public override void Stop () {
            target.DOKill();
            OnPlayEnd.Invoke();
        }
    }
}
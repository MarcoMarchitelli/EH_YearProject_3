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
        Tween tween;

        private void Awake () {
            startColor = target.color;
        }

        public override void Rewind () {
            //target.DOKill();

            tween.PlayBackwards();
            tween.onRewind += OnRewindEnd.Invoke;
            //target.DOColor( startColor, duration ).SetEase( ease ).SetLoops( loops ).onComplete += () => OnRewindEnd.Invoke();

            OnRewind.Invoke();
        }

        public override void Play () {
            target.DOKill();

            OnPlay.Invoke();

            if ( resetOnPlay == false )
                startColor = target.color;

            tween = target.DOColor( targetColor, duration ).SetEase( ease ).SetLoops( loops );

            tween.SetAutoKill( false );
            tween.timeScale = ignoresTimescale ? 1 : Time.timeScale;
            tween.onComplete += OnPlayEnd.Invoke;
        }

        public override void Stop () {
            tween.Kill();
            OnPlayEnd.Invoke();
        }
    }
}
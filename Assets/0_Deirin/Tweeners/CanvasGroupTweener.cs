namespace Deirin.Tweeners {
    using UnityEngine;
    using DG.Tweening;

    public class CanvasGroupTweener : BaseTweener {
        [Header("Specific Params")]
        public CanvasGroup target;
        [Range(0,1)] public float targetAlpha;
        public bool resetOnPlay = true;

        float startAlpha;

        private void Awake () {
            startAlpha = target.alpha;
        }

        public override void Rewind () {
            target.DOKill();
            target.DOFade( startAlpha, duration ).SetEase( ease ).SetLoops( loops ).onComplete += RewindEndHandler;
            OnRewind.Invoke();
        }

        public override void Play () {
            target.DOKill();
            OnPlay.Invoke();
            if ( resetOnPlay == false )
                startAlpha = target.alpha;
            target.DOFade( targetAlpha, duration ).SetEase( ease ).SetLoops( loops ).onComplete += PlayEndHandler;
        }

        public override void Stop () {
            target.DOKill();
            OnStop.Invoke();
        }

        private void RewindEndHandler () {
            OnRewindEnd.Invoke();
        }

        private void PlayEndHandler () {
            OnPlayEnd.Invoke();
        }
    }
}
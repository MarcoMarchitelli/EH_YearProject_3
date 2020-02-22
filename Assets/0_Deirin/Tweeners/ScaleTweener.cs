namespace Deirin.Tweeners {
    using UnityEngine;
    using DG.Tweening;
    using Deirin.Utilities;

    public class ScaleTweener : BaseTweener {
        [Header("Specific Params")]
        public Transform target;
        public Vector3 targetScale;
        public bool addToOriginal;
        public bool multiply;
        [Tooltip("Always starts from original scale.")]
        public bool resetOnPlay = true;

        private Vector3 startScale;
        private Vector3 endScale;

        private void Awake () {
            startScale = target.localScale;
        }

        public override void Rewind () {
            target.DOScale( startScale, duration ).SetEase( ease ).SetLoops( loops ).onComplete += () => OnPlayEnd.Invoke();
        }

        public override void Play () {
            OnPlay.Invoke();
            if ( resetOnPlay == false )
                startScale = target.localScale;
            endScale = multiply ? startScale.Mul( targetScale ) : targetScale;
            target.DOScale( addToOriginal ? startScale + endScale : endScale, duration ).SetEase( ease ).SetLoops( loops ).onComplete += () => OnPlayEnd.Invoke();
        }

        public override void Stop () {
            target.DOKill();
            OnPlayEnd.Invoke();
        }
    }
}
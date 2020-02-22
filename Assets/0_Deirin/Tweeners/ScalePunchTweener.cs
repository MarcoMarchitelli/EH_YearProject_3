namespace Deirin.Tweeners {
    using UnityEngine;
    using DG.Tweening;

    public class ScalePunchTweener : BaseTweener {
        [Header("Specific Params")]
        public Transform target;
        public Vector3 targetScale;
        public int vibrato = 10;
        [Range(0,1)] public float elasticity = 1;
        public bool addToOriginal;
        public bool resetOnPlay = true;

        private Vector3 startScale;
        private Vector3 endScale;

        private void Awake () {
            SetInitialVars();
        }

        private void SetInitialVars () {
            startScale = target.localScale;
            endScale = addToOriginal ? startScale + targetScale : targetScale;
        }

        public override void Rewind () {
            target.DOPunchScale( startScale, duration, vibrato, elasticity ).SetEase( ease ).onComplete += () => OnRewindEnd.Invoke();
            OnRewind.Invoke();
        }

        public override void Play () {
            OnPlay.Invoke();
            if ( resetOnPlay == false )
                SetInitialVars();
            target.DOPunchScale( endScale, duration, vibrato, elasticity ).SetEase( ease ).onComplete += () => OnPlayEnd.Invoke();
        }

        public override void Stop () {
            target.DOKill();
            OnStop.Invoke();
        }
    }
}
namespace Deirin.Tweeners {
    using UnityEngine;
    using DG.Tweening;

    public class ScaleTweener : BaseTweener {
        [Header("Specific Params")]
        public Transform target;
        public Vector3 targetScale;
        public bool addToOriginal;

        Vector3 startScale;

        public override void BackwardsTween () {
            target.DOScale( startScale, duration ).SetEase( ease ).SetLoops( loops ).onComplete += () => OnTweenerEnd.Invoke();
        }

        public override void PlayTween () {
            OnTweenerStart.Invoke();
            startScale = target.localScale;
            target.DOScale( addToOriginal ? startScale + targetScale : targetScale, duration ).SetEase( ease ).SetLoops( loops ).onComplete += () => OnTweenerEnd.Invoke();
        }

        public override void StopTween () {
            target.DOKill();
            OnTweenerEnd.Invoke();
        }
    }
}
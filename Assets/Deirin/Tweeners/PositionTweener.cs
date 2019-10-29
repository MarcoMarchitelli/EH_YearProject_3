namespace Deirin.Tweeners {
    using UnityEngine;
    using DG.Tweening;

    public class PositionTweener : BaseTweener {
        [Header("Specific Params")]
        public Transform target;
        public Vector3 targetPosition;
        public bool addToOriginal;

        Vector3 startPos;

        public override void BackwardsTween () {
            target.DOMove( startPos, duration ).SetEase( ease ).SetLoops( loops ).onComplete += () => OnTweenerEnd.Invoke();
        }

        public override void PlayTween () {
            OnTweenerStart.Invoke();
            startPos = target.position;
            target.DOMove( addToOriginal ? startPos + targetPosition : targetPosition, duration ).SetEase( ease ).SetLoops( loops ).onComplete += () => OnTweenerEnd.Invoke();
        }

        public override void StopTween () {
            target.DOKill();
            OnTweenerEnd.Invoke();
        }
    }
}
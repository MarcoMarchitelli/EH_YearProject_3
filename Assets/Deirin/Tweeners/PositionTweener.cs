namespace Deirin.Tweeners {
    using UnityEngine;
    using DG.Tweening;

    public class PositionTweener : BaseTweener {
        [Header("Specific Params")]
        public Transform target;
        public Vector3 targetPosition;
        public bool addToOriginal;
        public bool resetOnPlay = true;

        Vector3 startPos;

        private void Awake () {
            startPos = target.position;
        }

        public override void Rewind () {
            target.DOKill();
            target.DOMove( startPos, duration ).SetEase( ease ).SetLoops( loops ).onComplete += () => OnPlayEnd.Invoke();
        }

        public override void Play () {
            target.DOKill();
            OnPlay.Invoke();
            if ( resetOnPlay == false )
                startPos = target.position;
            target.DOMove( addToOriginal ? startPos + targetPosition : targetPosition, duration ).SetEase( ease ).SetLoops( loops ).onComplete += () => OnPlayEnd.Invoke();
        }

        public override void Stop () {
            target.DOKill();
            OnPlayEnd.Invoke();
        }
    }
}
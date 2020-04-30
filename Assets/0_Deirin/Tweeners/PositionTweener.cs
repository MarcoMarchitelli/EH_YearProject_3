namespace Deirin.Tweeners {
    using UnityEngine;
    using DG.Tweening;

    public class PositionTweener : BaseTweener {
        [Header("Specific Params")]
        public Transform target;
        public Vector3 targetPosition;
        public bool local = true;
        public bool addToOriginal;
        public bool resetOnPlay = true;
        public bool setStartPosOnAwake = false;

        Vector3 startPos;

        private void Awake () {
            if ( setStartPosOnAwake )
                startPos = local ? target.localPosition : target.position;
        }

        public void SetStartPos () {
            startPos = local ? target.localPosition : target.position;
        }

        public override void Rewind () {
            target.DOKill();
            if ( local )
                target.DOLocalMove( startPos, duration ).SetEase( ease ).SetLoops( loops ).onComplete += () => OnPlayEnd.Invoke();
            else
                target.DOMove( startPos, duration ).SetEase( ease ).SetLoops( loops ).onComplete += () => OnPlayEnd.Invoke();
        }

        public override void Play () {
            target.DOKill();

            if ( resetOnPlay == false )
                startPos = target.position;
            if ( local )
                target.DOLocalMove( addToOriginal ? startPos + targetPosition : targetPosition, duration ).SetEase( ease ).SetLoops( loops ).onComplete += () => OnPlayEnd.Invoke();
            else
                target.DOMove( addToOriginal ? startPos + targetPosition : targetPosition, duration ).SetEase( ease ).SetLoops( loops ).onComplete += () => OnPlayEnd.Invoke();
            
            OnPlay.Invoke();
        }

        public override void Stop () {
            target.DOKill();
            OnPlayEnd.Invoke();
        }
    }
}
namespace Deirin.Tweeners {
    using UnityEngine;
    using DG.Tweening;

    public class RectTransformTweener : BaseTweener {
        [Header("Specific Params")]
        public RectTransform target;
        public Vector2 targetSize;
        public Vector2 targetOffsetMin;
        public Vector2 targetOffsetMax;
        public bool addToOriginal;
        public bool resetOnPlay = true;

        private Sequence sequence;
        private Vector2 startSize;
        private Vector2 startOffsetMin, startOffsetMax;

        #region Monos
        private void Awake () {
            SetStartVars();
        }
        #endregion

        #region Privates
        private void SetStartVars () {
            startSize = target.sizeDelta;
            startOffsetMin = target.offsetMin;
            startOffsetMax = target.offsetMax;
        }

        private void SetOffsetMin ( Vector2 value ) {
            target.offsetMin = value;
        }

        private void SetOffsetMax ( Vector2 value ) {
            target.offsetMax = value;
        }

        private Vector2 GetOffsetMin () {
            return target.offsetMin;
        }

        private Vector2 GetOffsetMax () {
            return target.offsetMax;
        }
        #endregion

        protected override void AssignTween () {
            sequence = DOTween.Sequence();
            sequence.Append( DOTween.To( GetOffsetMin, SetOffsetMin, targetOffsetMin, duration ).SetEase( ease ) );
            sequence.Join( DOTween.To( GetOffsetMax, SetOffsetMax, targetOffsetMax, duration ).SetEase( ease ) );
            sequence.Join( target.DOSizeDelta( addToOriginal ? startSize + targetSize : targetSize, duration ).SetEase( ease ).SetLoops( loops ) );

            tween = sequence;
        }
    }
}
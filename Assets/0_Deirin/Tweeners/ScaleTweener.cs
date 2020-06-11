namespace Deirin.Tweeners {
    using UnityEngine;
    using DG.Tweening;

    public class ScaleTweener : BaseTweener {
        [Header("Specific Params")]
        public Transform target;
        public Vector3 targetScale;

        protected override void AssignTween () => tween = target.DOScale( targetScale, duration );
    }
}
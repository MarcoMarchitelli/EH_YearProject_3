namespace Deirin.Tweeners {
    using UnityEngine;
    using DG.Tweening;

    public class RotationTweener : BaseTweener {
        [Header("Specific Params")]
        public Transform target;
        public Vector3 targetEulers;
        public bool local = true;

        protected override void AssignTween () {
            if ( local )
                tween = target.DOLocalRotate( targetEulers, duration );
            else
                tween = target.DORotate( targetEulers, duration );
        }
    }
}
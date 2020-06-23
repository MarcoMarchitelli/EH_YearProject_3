namespace Deirin.Tweeners {
    using UnityEngine;
    using DG.Tweening;

    public class RotationPunchTweener : BaseTweener {
        [Header("Specific Params")]
        public Transform target;
        public Vector3 rotationPunch;
        public int vibrato = 10;
        [Range(0,1)] public float elasticity = 1;

        protected override void AssignTween () {
            tween = target.DOPunchRotation( rotationPunch, duration, vibrato, elasticity );
        }
    }
}
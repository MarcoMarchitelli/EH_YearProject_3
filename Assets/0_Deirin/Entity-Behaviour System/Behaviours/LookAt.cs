namespace Deirin.EB {
    using UnityEngine;
    using DG.Tweening;

    public class LookAt : BaseBehaviour {
        [Header("Refs")]
        public Transform target;

        [Header("Params")]
        public bool X;
        public bool Y;
        public bool Z;
        public Vector3 targetOffset;
        public float turnSpeed;

        private Quaternion startRotation;

        protected override void CustomSetup () {
            startRotation = transform.rotation;
        }

        public override void OnUpdate () {
            if ( !target )
                return;

            Vector3 targetPos = target.position + targetOffset;
            targetPos = new Vector3( X ? targetPos.x : transform.position.x, Y ? targetPos.y : transform.position.y, Z ? targetPos.z : transform.position.z );
            transform.localRotation = Quaternion.identity;
            Quaternion currentRotation = transform.localRotation;
            Quaternion targetRotation = Quaternion.LookRotation((targetPos - transform.position).normalized, transform.up);

            transform.rotation = Quaternion.Slerp(
                currentRotation,
                targetRotation,
                1 - Mathf.Exp( -turnSpeed * Time.deltaTime )
            );
        }

        public void SetTarget ( Transform target ) {
            this.target = target;
        }

        public void ReturnToTargetRotation () {
            target = null;
            transform.DOLocalRotateQuaternion( startRotation, .2f );
        }
    }
}
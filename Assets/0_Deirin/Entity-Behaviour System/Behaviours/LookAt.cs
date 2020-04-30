namespace Deirin.EB {
    using UnityEngine;

    public class LookAt : BaseBehaviour {
        [Header("Refs")]
        public Transform target;
        public Transform startTarget;

        [Header("Params")]
        public bool X;
        public bool Y;
        public bool Z;
        public Vector3 targetOffset;
        public float maxTurnAngle = 360;
        public float turnSpeed;

        public override void OnUpdate () {
            if ( !target )
                return;

            Vector3 targetPos = target.position + targetOffset;
            targetPos = new Vector3( X ? targetPos.x : transform.position.x, Y ? targetPos.y : transform.position.y, Z ? targetPos.z : transform.position.z );

            Quaternion currentLocalRotation = transform.localRotation;
            transform.localRotation = Quaternion.identity;

            Vector3 targetWorldLookDir = targetPos - transform.position;
            Vector3 targetLocalLookDir = transform.InverseTransformDirection(targetWorldLookDir);

            targetLocalLookDir = Vector3.RotateTowards(
              Vector3.forward,
              targetLocalLookDir,
              Mathf.Deg2Rad * maxTurnAngle,
              0
            );

            Quaternion targetLocalRotation = Quaternion.LookRotation(targetLocalLookDir, Vector3.up);

            transform.localRotation = Quaternion.Slerp(
              currentLocalRotation,
              targetLocalRotation,
              1 - Mathf.Exp( -turnSpeed * Time.deltaTime )
            );
        }

        public void SetTarget ( Transform target ) {
            this.target = target;
        }

        public void ReturnToTargetRotation () {
            target = startTarget;
        }

        public void RemoveTarget () {
            target = null;
        }
    }
}
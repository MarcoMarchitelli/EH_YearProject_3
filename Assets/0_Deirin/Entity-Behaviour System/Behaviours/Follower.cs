namespace Deirin.EB {
    using UnityEngine;
    using UnityEngine.Events;

    public class Follower : BaseBehaviour {
        [Header("Parameters")]
        public float speed;
        public Vector3 targetPositionOffset;
        [Min(0)] public float targetDistanceOffset;
        public bool stopFollowingOnReach = true;

        [Header("Events")]
        public UnityEvent OnTargetReached;
        public UnityEvent OnTargetLost;

        private BaseEntity target;
        private Vector3 orientation, targetPosition;
        private bool follow;

        #region Overrides
        public override void OnFixedUpdate () {
            if ( !follow )
                return;

            if ( target == null ) {
                OnTargetLost.Invoke();
                StopFollowing();
                return;
            }

            targetPosition = target.transform.position + targetPositionOffset;
            orientation = targetPosition - transform.position;
            transform.Translate( orientation.normalized * speed * Time.fixedDeltaTime, Space.World );
            transform.LookAt( targetPosition );
            CheckDistance();
        }
        #endregion

        #region API
        public void SetTarget ( BaseEntity target ) {
            this.target = target;
        }

        public void StartFollowing ( BaseEntity target ) {
            SetTarget( target );
            StartFollowing();
        }

        public void StartFollowing () {
            follow = target;
        }

        public void StopFollowing () {
            follow = false;
        }
        #endregion

        private void CheckDistance () {
            if ( orientation.sqrMagnitude <= targetDistanceOffset * targetDistanceOffset ) {
                OnTargetReached.Invoke();
                if ( stopFollowingOnReach )
                    StopFollowing();
            }
        }
    }
}
namespace Deirin.EB {
    using UnityEngine;
    using UnityEngine.Events;
    using SweetRage;

    public class Follower : BaseBehaviour {
        [Header("Parameters")]
        public float speed;
        public Vector3 targetPositionOffset;
        [Min(0)] public float targetDistanceOffset;
        public bool stopFollowingOnReach = true;

        [Header("Events")]
        public UnityEvent OnTargetReached;

        private BaseEntity target;
        private Vector3 orientation;
        private bool follow;

        #region Overrides
        public override void OnUpdate () {
            if ( !follow )
                return;

            orientation = (target.transform.position + targetPositionOffset) - transform.position;
            transform.Translate( orientation.normalized * speed * Time.deltaTime );
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
            if ( orientation.magnitude <= targetDistanceOffset ) {
                OnTargetReached.Invoke();
                if ( stopFollowingOnReach )
                    StopFollowing();
            }
        }
    }
}
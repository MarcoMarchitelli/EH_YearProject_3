namespace Deirin.EB {
    using UnityEngine;
    using UnityEngine.Events;

    public class PathPatroller : BaseBehaviour {
        [Header("Params")]
        [SerializeField] private float speed;
        public float minSpeed = 0;
        public float minWaypointDistance;
        public Vector3ArrayVariable pathPoints;
        public bool patrolOnSetup;

        [Header("Events")]
        public UnityEvent OnPatrolEnd;
        public UnityEvent OnPointReached;

        public float Speed => speed;
        public float CurrentSpeed => currentSpeed;

        private Vector3 currentTarget;
        private int currentTargetIndex = 0;
        private float startSpeed, currentSpeed;
        private bool patrolling;
        private Vector3 orientation, direction;
        private float sqrDistance;

        protected override void CustomSetup () {
            currentSpeed = startSpeed = speed;
            UpdateTargetPoint( currentTargetIndex );
            if ( patrolOnSetup )
                Patrol( true );
        }

        public override void OnUpdate () {
            if ( !patrolling )
                return;
            PatrolMovement();
        }

        public void Patrol ( bool value ) {
            patrolling = value;
        }

        public void ResetSpeed () {
            currentSpeed = startSpeed;
        }

        public void SetSpeed ( float value ) {
            currentSpeed = Mathf.Max( minSpeed, value );
        }

        private void PatrolMovement () {
            CheckDistance();

            transform.Translate( direction * currentSpeed * Time.deltaTime );
        }

        private void UpdateTargetPoint ( int index ) {
            if ( index > pathPoints.Value.Length - 1 || index < 0 ) {
                patrolling = false;
                return;
            }
            currentTarget = pathPoints.Value[index];
        }

        private void CheckDistance () {
            orientation = currentTarget - transform.position;
            sqrDistance = orientation.sqrMagnitude;
            direction = orientation.normalized;
            float sqrMinDist = minWaypointDistance * minWaypointDistance;
            if ( sqrDistance <= sqrMinDist ) {
                UpdateTargetPoint( currentTargetIndex++ );
            }
        }
    }
}
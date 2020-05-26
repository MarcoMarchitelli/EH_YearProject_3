namespace Deirin.EB {
    using UnityEngine;
    using UnityEngine.Events;

    public class PathPatroller : BaseBehaviour {
        #region Inspector
        [Header("Params")]
        public Vector3ArrayVariable pathPoints;
        [SerializeField] private float speed;
        public float minSpeed = 0;
        public float horizontalOffsetMin;
        public float horizontalOffsetMax;
        public bool patrolOnSetup;

        [Header("Events")]
        public UnityEvent OnPatrolEnd;
        public UnityEvent OnPointReached;
        #endregion

        public float Speed => speed;
        public float CurrentSpeed => currentSpeed;
        public float PathPercent => pathPercent;

        private Vector3 pointA, pointB;
        private int currentTargetIndex;
        private float startSpeed, currentSpeed;
        private bool patrolling;
        private float percent, currentSegmentLenght, pathPercent;
        private float offset;

        #region Overrides
        protected override void CustomSetup () {
            //initial setup
            patrolling = false;
            currentTargetIndex = 1;
            pathPercent = 0;

            startSpeed = speed;

            offset = Random.Range( horizontalOffsetMin, horizontalOffsetMax );

            if ( patrolOnSetup )
                StartPatrol();
        }

        public override void OnUpdate () {
            if ( patrolling )
                Patrol();
        }
        #endregion

        #region API
        public void StartPatrol () {
            CheckIfPatrolIsPossible();

            pointA = pathPoints.Value[0];
            pointB = pathPoints.Value[currentTargetIndex];

            AddOffsetToPoints();

            currentSegmentLenght = Vector3.Distance( pointA, pointB );
            currentSpeed = startSpeed;

            Resume();
        }

        public void Pause () {
            patrolling = false;
        }

        public void Resume () {
            patrolling = true;
        }

        public void ResetSpeed () {
            currentSpeed = startSpeed;
        }

        public void SetSpeed ( float value ) {
            currentSpeed = Mathf.Max( minSpeed, value );
        }
        #endregion

        private void Patrol () {
            percent += Time.deltaTime * currentSpeed / currentSegmentLenght;
            percent = Mathf.Clamp01( percent );
            transform.position = Vector3.Lerp( pointA, pointB, percent );
            pathPercent = ( currentTargetIndex - 1 + percent ) / pathPoints.Value.Length;

            if ( percent == 1 ) {
                UpdatePoints();
            }
        }

        private void UpdatePoints () {
            currentTargetIndex++;

            if ( currentTargetIndex > pathPoints.Value.Length - 1 || currentTargetIndex < 0 ) {
                patrolling = false;
                return;
            }

            pointA = pointB;
            pointB = pathPoints.Value[currentTargetIndex];

            AddOffsetToPoints();

            currentSegmentLenght = Vector3.Distance( pointA, pointB );
            percent = 0;
        }

        private void CheckIfPatrolIsPossible () {
            if ( pathPoints == null ) {
#if UNITY_EDITOR
                Debug.LogError( name + "'s path points variable is not set!" );
#endif
                return;
            }

            //if 1 or 0 points gtfo
            if ( pathPoints.Value.Length <= 1 ) {
#if UNITY_EDITOR
                Debug.LogError( name + "'s path points variable has 1 or less points in it!" );
#endif
                return;
            }
        }

        private void AddOffsetToPoints () {
            Vector3 localForward = ( pointB - pointA ).normalized;
            Vector3 localRight = Vector3.Cross( localForward, Vector3.up );

            pointA += offset * localRight;
            pointB += offset * localRight;
        }

        private void OnDrawGizmos () {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere( pointA, 1.5f );
            Gizmos.DrawSphere( pointB, 1.5f );
        }
    }
}
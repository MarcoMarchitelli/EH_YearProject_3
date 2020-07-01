namespace Deirin.EB {
    using Deirin.Utilities;
    using PathCreation;
    using UnityEngine;
    using UnityEngine.Events;

    public class PathPatroller : BaseBehaviour {
        #region Inspector
        [Header("Params")]
        [ReadOnly] public PathCreator pathCreator;
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

        private float startSpeed, currentSpeed;
        private bool patrolling;
        private float coveredPath;
        private float pathPercent;
        private float offset;

        #region Overrides
        protected override void CustomSetup () {
            //initial setup
            patrolling = false;
            coveredPath = 0;

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
            coveredPath += Time.deltaTime * currentSpeed;
            pathPercent = Mathf.Clamp01( coveredPath / pathCreator.path.length );

            Vector3 targetPos = pathCreator.path.GetPointAtDistance( coveredPath, PathCreation.EndOfPathInstruction.Stop );
            Vector3 targetDirection = pathCreator.path.GetDirectionAtDistance( coveredPath, PathCreation.EndOfPathInstruction.Stop );
            Vector3 upVector = pathCreator.path.GetNormalAtDistance( coveredPath, PathCreation.EndOfPathInstruction.Stop );

            transform.rotation = Quaternion.LookRotation( targetDirection, upVector );
            transform.position = targetPos + Vector3.Cross( targetDirection, upVector ) * offset;
        }

        private void CheckIfPatrolIsPossible () {
            if ( pathCreator == null ) {
#if UNITY_EDITOR
                Debug.LogError( name + "'s path points variable is not set!" );
#endif
                return;
            }
        }
    }
}
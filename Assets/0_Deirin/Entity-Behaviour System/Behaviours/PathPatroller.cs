namespace Deirin.EB {
    using UnityEngine;
    using UnityEngine.Events;
    using DG.Tweening;

    public class PathPatroller : BaseBehaviour {
        [Header("Params")]
        [SerializeField] private float speed;
        public Ease ease;
        public Vector3ArrayVariable pathPoints;
        public bool patrolOnSetup;

        [Header("Events")]
        public UnityEvent OnPatrolEnd;
        public UnityEvent OnPointReached;

        public float Speed => speed;

        private Vector3 currentTarget;
        int currentTargetIndex = 0;
        private float startSpeed, currentSpeed;

        protected override void CustomSetup () {
            currentSpeed = startSpeed = speed;
            if ( patrolOnSetup )
                Patrol( true );
        }

        public void Patrol ( bool value ) {
            if ( value )
                GetToTarget();
            else
                transform.DOKill();
        }

        public void ResetSpeed () {
            currentSpeed = startSpeed;
        }

        public void SetSpeed ( float value ) {
            currentSpeed = value;
        }

        private void GetToTarget () {
            currentTarget = pathPoints.Value[currentTargetIndex];
            float distance = Vector3.Distance( transform.position, currentTarget );
            float duration = distance / currentSpeed;
            transform.DOMove( currentTarget, duration ).SetEase( ease ).onComplete += () => {
                OnPointReached.Invoke();
                currentTargetIndex++;
                if ( currentTargetIndex < pathPoints.Value.Length )
                    GetToTarget();
                else
                    OnPatrolEnd.Invoke();
            };
        }
    }
}
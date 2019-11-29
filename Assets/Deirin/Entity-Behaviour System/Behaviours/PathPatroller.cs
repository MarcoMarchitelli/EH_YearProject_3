namespace Deirin.EB {
    using UnityEngine;
    using UnityEngine.Events;
    using DG.Tweening;

    public class PathPatroller : BaseBehaviour {
        [Header("Params")]
        public float speed;
        public Ease ease;
        public Vector3ArrayVariable pathPoints;
        public bool patrolOnSetup;

        [Header("Events")]
        public UnityEvent OnPatrolEnd;
        public UnityEvent OnPointReached;

        private Vector3 currentTarget;
        int currentTargetIndex = 0;

        protected override void CustomSetup () {
            if ( patrolOnSetup )
                Patrol( true );
        }

        public void Patrol ( bool value ) {
            if ( value )
                GetToTarget();
            else
                transform.DOKill();
        }

        private void GetToTarget () {
            currentTarget = pathPoints.Value[currentTargetIndex];
            float distance = Vector3.Distance( transform.position, currentTarget );
            float duration = distance / speed;
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
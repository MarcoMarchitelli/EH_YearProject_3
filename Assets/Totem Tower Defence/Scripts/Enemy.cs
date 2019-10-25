namespace TotemTD {
    using UnityEngine;
    using DG.Tweening;

    public class Enemy : MonoBehaviour {
        [Header("Params")]
        public int life;
        public float speed;
        public float turnRate;

        private Path path;
        private int currentTargetIndex;
        private Vector3 currentTarget;

        public void Setup ( Path path ) {
            this.path = path;
        }

        public void StartFollowingPath () {
            GetToTarget();
        }

        void GetToTarget () {
            currentTarget = path.points[currentTargetIndex];
            transform.DOMove( currentTarget, Vector3.Distance( transform.position, currentTarget ) / speed ).onComplete += () => {
                currentTargetIndex++;
                if ( currentTargetIndex < path.points.Length )
                    GetToTarget();
            };
        }
    }
}
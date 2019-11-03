namespace TotemTD {
    using UnityEngine;
    using DG.Tweening;

    public class Enemy : MonoBehaviour {
        [Header("Data")]
        public EnemyData data;

        public System.Action<int> OnLifeChange;
        public System.Action<Enemy> OnDeath;
        public System.Action OnSetup;

        private Path path;
        private int currentTargetIndex;
        private Vector3 currentTarget;

        private int life;
        private int armor;
        private float speed;

        public void Setup ( EnemyData data, Path path ) {
            this.data = data;
            life = data.life;
            armor = data.armor;
            speed = data.speed;
            this.path = path;
            OnSetup?.Invoke();
        }

        public void StartFollowingPath () {
            GetToTarget();
        }

        public void Damage ( int value ) {
            life -= value;
            OnLifeChange?.Invoke( life );
            if ( life <= 0 )
                Die();
        }

        void GetToTarget () {
            currentTarget = path.points[currentTargetIndex].position;
            float distance = Vector3.Distance( transform.position, currentTarget );
            float duration = distance / speed;
            transform.DOMove( currentTarget, duration ).SetEase(Ease.Linear).onComplete += () => {
                currentTargetIndex++;
                if ( currentTargetIndex < path.points.Length )
                    GetToTarget();
            };
        }

        void Die () {
            Destroy( gameObject );
            OnDeath?.Invoke( this );
        }
    }
}
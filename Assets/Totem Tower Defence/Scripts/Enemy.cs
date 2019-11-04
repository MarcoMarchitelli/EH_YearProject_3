namespace TotemTD {
    using UnityEngine;
    using DG.Tweening;
    using System.Collections.Generic;

    public class Enemy : MonoBehaviour {
        [Header("Data")]
        public EnemyData data;

        public System.Action<float> OnLifeChange;
        public System.Action<Enemy> OnDeath;
        public System.Action OnSetup;

        private Path path;
        private int currentTargetIndex;
        private Vector3 currentTarget;

        private float life;
        private int armor;
        public float speed;

        private List<TurretModData> mods;

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

        public void SetMods ( List<TurretModData> mods ) {
            this.mods = mods;
            foreach ( var item in this.mods ) {
                foreach ( var debuff in item.enemyDebuffs ) {
                    debuff.TargetEnemy = this;
                }
            }
        }

        public void Damage ( float value ) {
            life -= value;
            OnLifeChange?.Invoke( life );
            if ( life <= 0 )
                Die();
        }

        void GetToTarget () {
            currentTarget = path.points[currentTargetIndex].position;
            float distance = Vector3.Distance( transform.position, currentTarget );
            float duration = distance / speed;
            transform.DOMove( currentTarget, duration ).SetEase( Ease.Linear ).onComplete += () => {
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
namespace SweetRage {
    using UnityEngine;
    using UnityEngine.Events;
    using System.Collections.Generic;
    using Deirin.EB;
    using Deirin.Utilities;

    [RequireComponent( typeof( CapsuleCollider ) )]
    public class EnemyDetector : BaseBehaviour {
        [Header("Refs")]
        public CapsuleCollider capsuleCollider;

        [Header("Params")]
        public bool activeOnSetup;
        [SerializeField] private float range = 6;
        public LayerMask enemyMask;

        [Header("Events")]
        public UnityEvent_Entity OnTargetSet;
        public UnityEvent OnEnemiesLost;
        public UnityEvent_Float OnRangeSet;

        [ReadOnly] public List<Enemy> enemiesInRange;
        [ReadOnly] public Enemy currentTarget;

        public float Range => range;

        private bool active;
        private Collider[] objs;
        private Enemy tempEnemy;
        private float startRange;
        private int enemyCount;

        protected override void CustomSetup () {
            startRange = range;
            enemiesInRange = new List<Enemy>();
            Activate( activeOnSetup );
            RangeSetHandler();

            CustomGlobalTick.OnTick += CustomTickHandler;
        }

        private void CustomTickHandler () => CheckForFurthestEnemy();

        #region Monos
        private void OnTriggerEnter ( Collider other ) {
            if ( !active )
                return;
            if ( enemyMask == ( enemyMask | ( 1 << other.gameObject.layer ) ) ) {
                tempEnemy = other.GetComponentInParent<Enemy>();
                if ( tempEnemy ) {
#if UNITY_EDITOR
                    print( name + " found enemy!" );
#endif
                    if ( !enemiesInRange.Contains( tempEnemy ) )
                        AddEnemy( tempEnemy );
                }
            }
        }

        private void OnTriggerExit ( Collider other ) {
            if ( !active )
                return;
            if ( enemyMask == ( enemyMask | ( 1 << other.gameObject.layer ) ) ) {
                tempEnemy = other.GetComponentInParent<Enemy>();
                if ( tempEnemy ) {
#if UNITY_EDITOR
                    print( name + " lost enemy!" );
#endif
                    RemoveEnemy( tempEnemy );
                }
            }
        }
        #endregion

        #region API
        public void Activate ( bool value ) {
            active = value;
            capsuleCollider.enabled = value;
            ClearEnemies();
            if ( active ) {
#if UNITY_EDITOR
                print( name + " activated!" );
#endif
                FindAllEnemiesInRange();
            }
        }

        public void RemoveEnemy ( Enemy e ) {
            enemiesInRange.Remove( e );
            enemyCount = enemiesInRange.Count;

            if ( enemyCount == 0 ) {
                currentTarget = null;
                OnEnemiesLost.Invoke();
                return;
            }
            if ( e == currentTarget )
                GetFurthestEnemyAlongPath();
        }

        public void ResetRange () {
            range = startRange;
            RangeSetHandler();
        }

        public void SetRange ( float value ) {
            range = value;
            RangeSetHandler();
        }
        #endregion

        #region Privates
        private void ClearEnemies () {
            enemiesInRange.Clear();
            enemyCount = 0;
            currentTarget = null;

            OnEnemiesLost.Invoke();
        }

        private void AddEnemy ( Enemy e ) {
            enemiesInRange.Add( e );
            enemyCount = enemiesInRange.Count;

            if ( !currentTarget )
                SetCurrentTarget( e );
        }

        private void SetCurrentTarget ( Enemy target ) {
            currentTarget = target;
            OnTargetSet.Invoke( currentTarget );
        }

        private void GetFurthestEnemyAlongPath () {
            if ( enemyCount <= 0 )
                return;

            Enemy t = enemiesInRange[0];
            float maxPathPercent = t.pathPatroller.PathPercent;

            for ( int i = 1; i < enemyCount; i++ ) {
                Enemy tempEnemy = enemiesInRange[i];
                float tempPercent = tempEnemy.pathPatroller.PathPercent;
                if ( maxPathPercent < tempPercent ) {
                    maxPathPercent = tempPercent;
                    t = tempEnemy;
                }
            }

            SetCurrentTarget( t );
        }

        private void CheckForFurthestEnemy () {
            if ( enemyCount <= 0 )
                return;

            if ( currentTarget == null )
                return;

            Enemy t = null;
            float maxPathPercent = currentTarget.pathPatroller.PathPercent;

            for ( int i = 1; i < enemyCount; i++ ) {
                Enemy tempEnemy = enemiesInRange[i];
                float tempPercent = tempEnemy.pathPatroller.PathPercent;
                if ( maxPathPercent < tempPercent ) {
                    maxPathPercent = tempPercent;
                    t = tempEnemy;
                }
            }

            if ( t )
                SetCurrentTarget( t );
        }

        private void FindAllEnemiesInRange () {
            objs = Physics.OverlapSphere( capsuleCollider.transform.position, capsuleCollider.radius, enemyMask );
            for ( int i = 0; i < objs.Length; i++ ) {
                if ( objs[i].TryGetComponent( out tempEnemy ) )
                    enemiesInRange.Add( tempEnemy );
            }
            enemyCount = enemiesInRange.Count;
            GetFurthestEnemyAlongPath();
        }

        private void RangeSetHandler () {
            capsuleCollider.radius = range;
            OnRangeSet.Invoke( range );
        }
        #endregion
    }

    [System.Serializable]
    public class UnityTransformEvent : UnityEvent<Transform> { }
}
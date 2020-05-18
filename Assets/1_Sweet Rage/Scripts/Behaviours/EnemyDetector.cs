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

        protected override void CustomSetup () {
            startRange = range;
            enemiesInRange = new List<Enemy>();
            Activate( activeOnSetup );
            RangeSetHandler();
        }

        #region Monos
        private void OnTriggerEnter ( Collider other ) {
            if ( !active )
                return;
            if ( enemyMask == ( enemyMask | ( 1 << other.gameObject.layer ) ) ) {
                tempEnemy = other.GetComponentInParent<Enemy>();
                if ( tempEnemy ) {
                    print( name + " found enemy!" );
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
                    print( name + " lost enemy!" );
                    RemoveEnemy( tempEnemy );
                }
            }
        }
        #endregion

        #region API
        public void Activate ( bool value ) {
            //if ( value == active )
            //    return;

            active = value;
            capsuleCollider.enabled = value;
            ClearEnemies();
            if ( active ) {
                print( name + " activated!" );
                FindAllEnemiesInRange();
            }
        }

        public void RemoveEnemy ( Enemy e ) {
            enemiesInRange.Remove( e );
            if ( enemiesInRange.Count == 0 ) {
                currentTarget = null;
                OnEnemiesLost.Invoke();
                return;
            }
            if ( e == currentTarget )
                FindClosestTarget();
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
            currentTarget = null;
            OnEnemiesLost.Invoke();
        }

        private void AddEnemy ( Enemy e ) {
            enemiesInRange.Add( e );
            if ( !currentTarget )
                SetCurrentTarget( e );
        }

        private void SetCurrentTarget ( Enemy target ) {
            currentTarget = target;
            OnTargetSet.Invoke( currentTarget );
        }

        private void FindClosestTarget () {
            int enemyCount = enemiesInRange.Count;
            if ( enemyCount == 0 )
                return;
            Enemy t = enemiesInRange[0];
            float dist = Vector3.Distance( t.transform.position, transform.position );
            for ( int i = 1; i < enemyCount; i++ ) {
                float newDist = Vector3.Distance( enemiesInRange[i].transform.position, transform.position );
                if ( newDist < dist ) {
                    dist = newDist;
                    t = enemiesInRange[i];
                }
            }
            SetCurrentTarget( t );
        }

        private void FindAllEnemiesInRange () {
            objs = Physics.OverlapSphere( capsuleCollider.transform.position, capsuleCollider.radius, enemyMask );
            for ( int i = 0; i < objs.Length; i++ ) {
                if ( objs[i].TryGetComponent( out tempEnemy ) )
                    enemiesInRange.Add( tempEnemy );
            }
            FindClosestTarget();
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
namespace SweetRage {
    using UnityEngine;
    using UnityEngine.Events;
    using System.Collections.Generic;
    using Deirin.EB;
    using Deirin.Utilities;

    [RequireComponent( typeof( SphereCollider ) )]
    public class EnemyDetector : BaseBehaviour {
        [Header("Refs")]
        public SphereCollider sphereCollider;
        public GameObject rangeGraphics;

        [Header("Params")]
        public bool activeOnSetup;
        [SerializeField] private float range = 6;
        public LayerMask enemyMask;

        [Header("Events")]
        public UnityEvent_Entity OnTargetSet;
        public UnityEvent OnEnemiesLost;

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
                    RemoveEnemy( tempEnemy );
                }
            }
        }
        #endregion

        #region API
        public void Activate ( bool value ) {
            if ( value == active )
                return;

            active = value;
            sphereCollider.enabled = value;
            ClearEnemies();
            if ( active )
                FindAllEnemiesInRange();
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
            objs = Physics.OverlapSphere( sphereCollider.transform.position, sphereCollider.radius, enemyMask );
            for ( int i = 0; i < objs.Length; i++ ) {
                if ( objs[i].TryGetComponent( out tempEnemy ) )
                    enemiesInRange.Add( tempEnemy );
            }
            FindClosestTarget();
        }

        private void RangeSetHandler () {
            sphereCollider.radius = range;
            rangeGraphics.transform.localScale = Vector3.one * ( range * 5 );
        }
        #endregion
    }

    [System.Serializable]
    public class UnityTransformEvent : UnityEvent<Transform> { }
}
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
        public float range = 6;

        [Header("Events")]
        public UnityTransformEvent OnEnemyDetected;
        public UnityEvent OnEnemiesLost;

        [ReadOnly] public List<Enemy> enemiesInRange;
        [ReadOnly] public Enemy currentTarget;

        private bool active;

        protected override void CustomSetup () {
            enemiesInRange = new List<Enemy>();
            Activate( activeOnSetup );
            sphereCollider.radius = range;
            rangeGraphics.transform.localScale = Vector3.one * ( range + 2 );
        }

        private void OnTriggerEnter ( Collider other ) {
            if ( !active )
                return;
            Enemy e = other.GetComponentInParent<Enemy>();
            if ( e ) {
                if ( !enemiesInRange.Contains( e ) )
                    AddEnemy( e );
            }
        }

        private void OnTriggerExit ( Collider other ) {
            if ( !active )
                return;
            Enemy e = other.GetComponentInParent<Enemy>();
            if ( e ) {
                if ( enemiesInRange.Contains( e ) )
                    RemoveEnemy( e );
            }
        }

        public void Activate ( bool value ) {
            active = value;
            sphereCollider.enabled = value;
        }

        public void RemoveEnemy ( Enemy e ) {
            if ( enemiesInRange.Contains( e ) == false )
                return;
            enemiesInRange.Remove( e );
            if ( enemiesInRange.Count == 0 ) {
                OnEnemiesLost.Invoke();
                currentTarget = null;
                return;
            }
            if ( e == currentTarget )
                FindClosestTarget();
        }

        private void AddEnemy ( Enemy e ) {
            enemiesInRange.Add( e );
            if ( !currentTarget )
                SetCurrentTarget( e );
        }

        private void SetCurrentTarget ( Enemy target ) {
            currentTarget = target;
            OnEnemyDetected.Invoke( currentTarget.transform );
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
    }

    [System.Serializable]
    public class UnityTransformEvent : UnityEvent<Transform> { }
}
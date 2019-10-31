namespace TotemTD {
    using UnityEngine;
    using UnityEngine.Events;
    using System.Collections.Generic;

    [RequireComponent( typeof( SphereCollider ) )]
    public class EnemyDetector : MonoBehaviour {
        [Header("Refs")]
        public SphereCollider sphereCollider;
        public GameObject rangeGraphicsBorder;
        public GameObject rangeGraphics;
        public Material rangeBorderMat;
        public Material rangeMat;

        [Header("Params")]
        public bool active;
        public float range = 6;

        [Header("Events")]
        public UnityTransformEvent OnEnemyDetected;
        public UnityEvent OnEnemiesLost;

        public List<Enemy> enemiesInRange = new List<Enemy>();
        public Enemy currentTarget;

        public void Setup () {
            sphereCollider.radius = range;
            rangeGraphicsBorder.transform.localScale = Vector3.one * ( range + 1 );
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
        }

        public void ChangeColor ( Color color ) {
            rangeMat.SetColor( "_Color", color );
            rangeBorderMat.SetColor( "_Color", color );
        }

        private void AddEnemy ( Enemy e ) {
            enemiesInRange.Add( e );
            e.OnDeath += RemoveEnemy;
            if ( !currentTarget )
                SetCurrentTarget( e );
        }

        private void RemoveEnemy ( Enemy e ) {
            e.OnDeath -= RemoveEnemy;
            enemiesInRange.Remove( e );
            if ( enemiesInRange.Count == 0 ) {
                OnEnemiesLost.Invoke();
                currentTarget = null;
                return;
            }
            if ( e == currentTarget )
                FindClosestTarget();
        }

        private void SetCurrentTarget ( Enemy target ) {
            currentTarget = target;
            OnEnemyDetected.Invoke( currentTarget.transform );
        }

        private void FindClosestTarget () {
            Enemy t = null;
            float dist = range + 1;
            for ( int i = 0; i < enemiesInRange.Count; i++ ) {
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
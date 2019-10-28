namespace TotemTD {
    using UnityEngine;
    using UnityEngine.Events;
    using System.Collections.Generic;

    [RequireComponent( typeof( Collider ) )]
    public class EnemyDetector : MonoBehaviour {
        [Header("Params")]
        public bool active;

        [Header("Events")]
        public UnityEvent OnEnemyDetected, OnEnemiesLost;

        private List<Enemy> enemiesInRange = new List<Enemy>();
        private Enemy currentTarget;

        private void OnTriggerEnter ( Collider other ) {
            if ( !active )
                return;
            Enemy e = other.GetComponentInParent<Enemy>();
            if ( e ) {
                currentTarget = e;
                enemiesInRange.Add( e );
                OnEnemyDetected.Invoke();
            }
        }

        private void OnTriggerExit ( Collider other ) {
            if ( !active )
                return;
            Enemy e = other.GetComponentInParent<Enemy>();
            if ( e ) {
                enemiesInRange.Remove( e );
                if ( enemiesInRange.Count == 0 ) {
                    OnEnemiesLost.Invoke();
                }
            }
        }

        public void Activate ( bool value ) {
            active = value;
        }
    }
}
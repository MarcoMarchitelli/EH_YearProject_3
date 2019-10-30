namespace TotemTD {
    using UnityEngine;
    using UnityEngine.Events;
    using System.Collections.Generic;

    [RequireComponent( typeof( Collider ) )]
    public class EnemyDetector : MonoBehaviour {
        [Header("Params")]
        public bool active;

        [Header("Events")]
        public UnityTransformEvent OnEnemyDetected;
        public UnityEvent OnEnemiesLost;

        private List<Enemy> enemiesInRange = new List<Enemy>();
        private Enemy currentTarget;
        private int currentTargetIndex;

        private void OnTriggerEnter ( Collider other ) {
            if ( !active )
                return;
            Enemy e = other.GetComponentInParent<Enemy>();
            if ( e ) {
                if ( enemiesInRange.Contains( e ) )
                    return;
                enemiesInRange.Add( e );
                currentTarget = e;
                currentTargetIndex++;
                OnEnemyDetected.Invoke( currentTarget.transform );
            }
        }

        private void OnTriggerExit ( Collider other ) {
            if ( !active )
                return;
            Enemy e = other.GetComponentInParent<Enemy>();
            if ( e ) {
                if ( e == currentTarget ) {
                    currentTargetIndex--;
                    currentTarget = enemiesInRange[currentTargetIndex];
                }
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

    [System.Serializable]
    public class UnityTransformEvent : UnityEvent<Transform> {

    }
}
namespace TotemTD {
    using UnityEngine;
    using UnityEngine.Events;

    [RequireComponent( typeof( Collider ) )]
    public class EnemyDamageDealer : MonoBehaviour {
        [Header("Params")]
        public int damage;

        [Header("Events")]
        public UnityEnemyEvent OnDamageDealt;

        private void OnTriggerEnter ( Collider other ) {
            Enemy e = other.GetComponentInParent<Enemy>();
            if ( e ) {
                e.Damage( damage );
                Die();
                OnDamageDealt.Invoke( e );
            }
        }

        void Die () {
            Destroy( gameObject );
        }
    }

    [System.Serializable]
    public class UnityEnemyEvent : UnityEvent<Enemy> {

    }
}
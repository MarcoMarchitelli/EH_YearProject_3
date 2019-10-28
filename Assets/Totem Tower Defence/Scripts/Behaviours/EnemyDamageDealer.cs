namespace TotemTD {
    using UnityEngine;
    using UnityEngine.Events;

    [RequireComponent( typeof( Collider ) )]
    public class EnemyDamageDealer : MonoBehaviour {
        [Header("Params")]
        public int damage;

        [Header("Events")]
        public UnityEvent OnDamageDealt;

        private void OnTriggerEnter ( Collider other ) {
            Enemy e = other.GetComponent<Enemy>();
            if ( e ) {
                e.Damage( damage );
                Die();
                OnDamageDealt.Invoke();
            }
        }

        void Die () {
            Destroy( gameObject );
        }
    }
}
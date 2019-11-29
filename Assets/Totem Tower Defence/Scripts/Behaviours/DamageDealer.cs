namespace TotemTD {
    using UnityEngine;
    using UnityEngine.Events;

    [RequireComponent( typeof( Collider ) )]
    public class DamageDealer : BaseBehaviour {
        [Header("Params")]
        public int damage;

        [Header("Events")]
        public UnityEvent OnDamageDealt;

        DamageReceiver target;

        private void OnTriggerEnter ( Collider other ) {
            if(other.TryGetComponent(out target ) ) {
                target.Damage( damage );
                OnDamageDealt.Invoke();
            }
        }
    }
}
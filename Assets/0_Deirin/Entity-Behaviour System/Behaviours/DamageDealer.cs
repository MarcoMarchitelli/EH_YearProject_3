namespace Deirin.EB {
    using Deirin.Utilities;
    using UnityEngine;

    [RequireComponent( typeof( Collider ) )]
    public class DamageDealer : BaseBehaviour {
        [Header("Params")]
        public int damage;

        [Header("Events")]
        public UnityEvent_Entity OnDamageDealt;

        DamageReceiver damageReceiver;

        private void OnTriggerEnter ( Collider other ) {
            damageReceiver = other.GetComponentInChildren<DamageReceiver>();
            if ( damageReceiver ) {
                damageReceiver.Damage( damage );
                OnDamageDealt.Invoke( damageReceiver.Entity );
            }
        }
    }
}
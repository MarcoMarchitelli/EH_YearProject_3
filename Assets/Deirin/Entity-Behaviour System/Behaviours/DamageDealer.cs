﻿namespace Deirin.EB {
    using UnityEngine;
    using UnityEngine.Events;

    [RequireComponent( typeof( Collider ) )]
    public class DamageDealer : BaseBehaviour {
        [Header("Params")]
        public int damage;

        [Header("Events")]
        public UnityEvent OnDamageDealt;

        DamageReceiver damageReceiver;

        private void OnTriggerEnter ( Collider other ) {
            damageReceiver = other.GetComponentInChildren<DamageReceiver>();
            if ( damageReceiver ) {
                damageReceiver.Damage( damage );
                OnDamageDealt.Invoke();
            }
        }
    }
}
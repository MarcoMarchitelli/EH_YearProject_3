namespace Deirin.EB {
    using UnityEngine;
    using UnityEngine.Events;
    using Deirin.Utilities;

    public class DamageReceiverContainer : BaseBehaviour {
        [Header("Parameters")]
        public DamageReceiver damageReceiver;

        [Header("Events")]
        public UnityEvent OnDamageDealerSet;
        public UnityEvent_Entity OnDamageDealt;

        #region API
        public void GetDamageDealer ( BaseEntity entity ) {
            if ( entity.TryGetBehaviour( out damageReceiver ) ) {
                OnDamageDealerSet.Invoke();
            }
        }

        public void DealDamage ( float damage ) {
            if ( damageReceiver == null )
                return;
            OnDamageDealt.Invoke( damageReceiver.Entity );
            damageReceiver.Damage( damage );
        }
        #endregion
    }
}
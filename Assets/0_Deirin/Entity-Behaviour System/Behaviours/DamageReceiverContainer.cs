namespace SweetRage {
    using UnityEngine;
    using UnityEngine.Events;
    using Deirin.EB;

    public class DamageReceiverContainer : BaseBehaviour {
        [Header("Parameters")]
        public DamageReceiver damageReceiver;

        [Header("Events")]
        public UnityEvent OnDamageDealerSet;

        #region API
        public void GetDamageDealer ( BaseEntity entity ) {
            if ( entity.TryGetBehaviour( out damageReceiver ) )
                OnDamageDealerSet.Invoke();
        }

        public void DealDamage ( float damage ) {
            if ( damageReceiver == null )
                return;
            damageReceiver.Damage( damage );
        }
        #endregion
    }
}
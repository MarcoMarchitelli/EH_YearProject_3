namespace Deirin.EB {
    using UnityEngine;
    using UnityEngine.Events;
    using Deirin.Utilities;

    public class DamageReceiverContainer : BaseBehaviour, IDamager {
        [Header("Parameters")]
        public DamageReceiver damageReceiver;
        [SerializeField] private float defaultDamage;

        [Header("Events")]
        public UnityEvent OnDamageDealerSet;
        public UnityEvent_Entity OnDamageDealt;

        private float startDamage;

        protected override void CustomSetup () {
            startDamage = defaultDamage;
        }

        #region IDamager
        public float Damage => defaultDamage;

        public void DealDamage ( float damage ) {
            if ( damageReceiver == null )
                return;
            OnDamageDealt.Invoke( damageReceiver.Entity );
            damageReceiver.Damage( damage );
        }

        public void DealDamage () {
            if ( damageReceiver == null )
                return;
            OnDamageDealt.Invoke( damageReceiver.Entity );
            damageReceiver.Damage( defaultDamage );
        }

        public void SetDamage ( float value ) {
            defaultDamage = value;
        }

        public void ResetDamage () {
            defaultDamage = startDamage;
        }
        #endregion

        #region API
        public void GetDamageDealer ( BaseEntity entity ) {
            if ( entity.TryGetBehaviour( out damageReceiver ) ) {
                OnDamageDealerSet.Invoke();
            }
        }
        #endregion
    }
}
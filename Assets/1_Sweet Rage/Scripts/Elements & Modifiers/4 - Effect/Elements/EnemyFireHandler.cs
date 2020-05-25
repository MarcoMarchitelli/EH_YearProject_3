namespace SweetRage {
    using Deirin.EB;
    using UnityEngine;
    using UnityEngine.Events;

    public class EnemyFireHandler : AbsEnemyElementHandler {
        [Header("Fire Params"), Space]
        public FireTickValues[] fireTickValues;

        [Header("Fire Events"), Space]
        public UnityEvent OnTick;

        private DamageReceiver damageReceiver;
        private FireTickValues currentTickValue;
        private bool active;
        private float timer;

        private void OnDisable () {
            OnCurrentChargeIncreases.RemoveListener( ChargeChangeHandler );
            OnCurrentChargeDecreases.RemoveListener( ChargeChangeHandler );
        }

        protected override void CustomSetup () {
            base.CustomSetup();

            Entity.TryGetBehaviour( out damageReceiver );

            if ( damageReceiver ) {
                OnCurrentChargeIncreases.AddListener( ChargeChangeHandler );
                OnCurrentChargeDecreases.AddListener( ChargeChangeHandler );
            }
#if UNITY_EDITOR
            else {
                print( name + " could not find damage receiver" );
            }
#endif
        }

        public override void OnUpdate () {
            if ( !active )
                return;

            timer += Time.deltaTime;
            if ( timer >= currentTickValue.tickFrequence ) {
                timer = 0;
                damageReceiver.Damage( currentTickValue.dpt );
            }
        }

        private void ChargeChangeHandler ( int currentCharge ) {
            if ( currentCharge == 0 )
                active = false;

            int count = fireTickValues.Length;
            if ( damageReceiver && currentCharge > 0 && count > 0 && count >= currentCharge ) {
                active = true;
                currentTickValue = fireTickValues[currentCharge - 1];
            }
        }
    }

    [System.Serializable]
    public class FireTickValues {
        [Tooltip("Danni inflitti ad ogni tick")]
        public float dpt = 1;
        [Tooltip("Frequenza di applicazione dei danni")]
        public float tickFrequence = 0.5f;
    }
}
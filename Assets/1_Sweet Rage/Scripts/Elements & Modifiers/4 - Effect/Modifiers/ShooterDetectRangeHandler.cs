namespace SweetRage {
    public class ShooterDetectRangeHandler : AbsShooterModifierHandler {
        public Buff[] fireRates;

        private EnemyDetector enemyDetector;
        private Buff currentFireRateMod;

        private void OnDestroy () {
            OnCurrentChargeIncreases.RemoveListener( ChargeChangeHandler );
            OnCurrentChargeDecreases.RemoveListener( ChargeChangeHandler );
        }

        protected override void CustomSetup () {
            base.CustomSetup();

            Entity.TryGetBehaviour( out enemyDetector );

            if ( enemyDetector ) {
                OnCurrentChargeIncreases.AddListener( ChargeChangeHandler );
                OnCurrentChargeDecreases.AddListener( ChargeChangeHandler );
            }
#if UNITY_EDITOR
            else {
                print( name + " could not find enemy detector" );
            }
#endif
        }

        private void ChargeChangeHandler ( int currentCharge ) {
            int count = fireRates.Length;
            if ( enemyDetector )
                enemyDetector.ResetRange();
            if ( currentCharge > 0 && count > 0 && count >= currentCharge ) {
                currentFireRateMod = fireRates[currentCharge - 1];
                if ( currentFireRateMod.buffMode == Buff.BuffMode.Percentage )
                    enemyDetector.SetRange( enemyDetector.Range + enemyDetector.Range * currentFireRateMod.percentBuff );
                else
                    enemyDetector.SetRange( enemyDetector.Range + currentFireRateMod.flatBuff );
            }
        }
    }
}
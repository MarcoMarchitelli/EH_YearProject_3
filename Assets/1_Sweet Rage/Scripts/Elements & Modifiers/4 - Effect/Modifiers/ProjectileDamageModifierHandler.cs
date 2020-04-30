namespace SweetRage {
    using Deirin.EB;

    public class ProjectileDamageModifierHandler : AbsShooterModifierHandler {
        public Buff[] buffs;

        private Buff currentFireRateMod;
        private IDamager damager;

        private void OnDestroy () {
            OnCurrentChargeIncreases.RemoveListener( ChargeChangeHandler );
            OnCurrentChargeDecreases.RemoveListener( ChargeChangeHandler );
        }

        protected override void CustomSetup () {
            base.CustomSetup();

            damager = Entity.GetComponentInChildren<IDamager>();

            if ( damager != null ) {
                OnCurrentChargeIncreases.AddListener( ChargeChangeHandler );
                OnCurrentChargeDecreases.AddListener( ChargeChangeHandler );
            }
#if UNITY_EDITOR
            else {
                print( name + " could not find IDamager" );
            }
#endif
        }

        private void ChargeChangeHandler ( int currentCharge ) {
            int count = buffs.Length;
            if ( damager != null )
                damager.ResetDamage();
            if ( currentCharge > 0 && count > 0 && count >= currentCharge ) {
                currentFireRateMod = buffs[currentCharge - 1];
                if ( currentFireRateMod.buffMode == Buff.BuffMode.Percentage )
                    damager.SetDamage( damager.Damage + damager.Damage * currentFireRateMod.percentBuff );
                else
                    damager.SetDamage( damager.Damage + currentFireRateMod.flatBuff );
            }
        }
    }
}
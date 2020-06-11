namespace SweetRage {
    using Deirin.EB;
    using UnityEngine;
    using UnityEngine.Events;

    public class ShooterElementHandler : AbsEffectHandler<ElementScriptableEnum> {
        [SerializeField] private ElementScriptableEnum _elementType;

        public override IEffectEnum effectType => _elementType;

        private void OnDisable () {
            //OnCurrentChargeIncreases.RemoveListener( ChargeChangeHandler );
            //OnCurrentChargeDecreases.RemoveListener( ChargeChangeHandler );
        }
    }
}
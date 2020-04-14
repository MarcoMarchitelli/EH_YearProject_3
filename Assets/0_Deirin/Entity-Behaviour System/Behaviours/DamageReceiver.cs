namespace Deirin.EB {
    using UnityEngine;
    using UnityEngine.Events;
    using Deirin.Utilities;

    public class DamageReceiver : BaseBehaviour {
        [Header("Params")]
        public float maxLife;
        public bool maxLifeOnSetup = true;

        [Header("Events")]
        public UnityEvent_Float OnLifeChanged;
        public UnityEvent_Float OnLifeChangedPercent;
        public UnityEvent OnLifeDepeleated;

        private float currentLife;

        protected override void CustomSetup () {
            if ( maxLifeOnSetup )
                currentLife = maxLife;
        }

        public void Damage ( float value ) {
            currentLife -= value;
            OnLifeChanged.Invoke( currentLife );
            OnLifeChangedPercent.Invoke( currentLife / maxLife );
            if ( currentLife <= 0 )
                OnLifeDepeleated.Invoke();
        }
    }
}
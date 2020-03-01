namespace Deirin.EB {
    using UnityEngine;
    using UnityEngine.Events;
    using Deirin.Utilities;

    public class DamageReceiver : BaseBehaviour {
        [Header("Params")]
        public float maxLife;
        public bool maxLifeOnAwake = true;

        [Header("Events")]
        public UnityEvent_Float OnLifeChanged;
        public UnityEvent_Float OnLifeChangedPercent;
        public UnityEvent OnLifeDepeleated;

        private float currentLife;

        public override void OnAwake () {
            if ( maxLifeOnAwake )
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
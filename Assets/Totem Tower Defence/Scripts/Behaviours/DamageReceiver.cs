namespace TotemTD {
    using UnityEngine;
    using UnityEngine.Events;

    public class DamageReceiver : BaseBehaviour {
        [Header("Params")]
        public int life;

        [Header("Events")]
        public UnityIntEvent OnLifeChanged;
        public UnityEvent OnLifeDepeleated;

        public void Damage ( int value ) {
            life -= value;
            if ( life <= 0 )
                OnLifeDepeleated.Invoke();
            else
                OnLifeChanged.Invoke( life );
        }
    }
}
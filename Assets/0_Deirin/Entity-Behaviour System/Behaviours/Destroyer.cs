namespace Deirin.EB {
    using UnityEngine;
    using UnityEngine.Events;

    public class Destroyer : BaseBehaviour {
        [Header("Params")]
        public GameObject target;
        public float delay;

        [Header("Events")]
        public UnityEvent OnDestruction;

        public void Destroy () {
            Destroy( gameObject );
            OnDestruction.Invoke();
        }
    }
}
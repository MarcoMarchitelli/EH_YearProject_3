namespace TotemTD {
    using UnityEngine;
    using UnityEngine.Events;

    public class Destroyer : MonoBehaviour {
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
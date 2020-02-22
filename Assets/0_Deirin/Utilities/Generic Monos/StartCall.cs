namespace Deirin.Utilities {
    using UnityEngine;
    using UnityEngine.Events;

    public class StartCall : MonoBehaviour {
        public UnityEvent OnStart;
        private void Start () {
            OnStart.Invoke();
        }
    }
}
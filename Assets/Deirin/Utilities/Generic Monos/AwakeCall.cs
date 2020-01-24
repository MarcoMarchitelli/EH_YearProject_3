namespace Deirin.Utilities {
    using UnityEngine;
    using UnityEngine.Events;

    public class AwakeCall : MonoBehaviour {
        public UnityEvent OnAwake;
        private void Awake () {
            OnAwake.Invoke();
        }
    }
}
namespace Deirin.EB {
    using UnityEngine.Events;

    public class OnEnableBehaviour : BaseBehaviour {
        public UnityEvent onEnable;

        public override void OnOnEnable () {
            onEnable.Invoke();
        }
    }
}
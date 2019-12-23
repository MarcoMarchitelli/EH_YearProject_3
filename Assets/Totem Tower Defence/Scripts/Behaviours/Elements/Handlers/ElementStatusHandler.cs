namespace TotemTD {
    using UnityEngine;
    using UnityEngine.Events;
    using Deirin.EB;

    public abstract class ElementStatusHandler : BaseBehaviour {
        [Header("Events")]
        public UnityEvent OnStatusApply;
        public UnityEvent OnStatusRemove;

        [HideInInspector] public Element element;

        public void Apply ( Element element ) {
            this.element = element;
            CustomApply();
            OnStatusApply.Invoke();
        }

        public void Remove () {
            this.element = null;
            CustomRemove();
            OnStatusApply.Invoke();
        }

        protected virtual void CustomApply () {

        }

        protected virtual void CustomRemove () {

        }
    }
}
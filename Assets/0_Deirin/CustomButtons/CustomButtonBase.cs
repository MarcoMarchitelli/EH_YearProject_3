namespace Deirin.CustomButton {
    using UnityEngine;

    public abstract class CustomButtonBase : MonoBehaviour {
        public System.Action OnSelection, OnDeselection, OnClick;

        protected bool selected;
        public bool active;

        public void Active ( bool value ) {
            active = value;
        }

        public void Select () {
            if ( !active )
                return;

            if ( selected )
                return;

            selected = true;
            OnSelection?.Invoke();
        }

        public void Deselect () {
            if ( !active )
                return;

            if ( !selected )
                return;

            selected = false;
            OnDeselection?.Invoke();
        }

        public void Click () {
            if ( !active )
                return;

            if ( !selected )
                return;

            OnClick?.Invoke();
        }
    }
}
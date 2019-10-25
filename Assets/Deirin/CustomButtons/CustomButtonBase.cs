namespace Deirin.CustomButton {
    using UnityEngine;

    public abstract class CustomButtonBase : MonoBehaviour {
        public System.Action OnSelection, OnDeselection, OnClick;

        protected bool selected;

        public void Select () {
            if ( selected )
                return;

            selected = true;
            OnSelection?.Invoke();
        }

        public void Deselect () {
            if ( !selected )
                return;

            selected = false;
            OnDeselection?.Invoke();
        }

        public void Click () {
            if ( !selected )
                return;

            OnClick?.Invoke();
        }
    } 
}
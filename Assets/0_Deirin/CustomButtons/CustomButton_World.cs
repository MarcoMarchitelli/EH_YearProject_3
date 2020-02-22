namespace Deirin.CustomButton {
    using UnityEngine;
    using UnityEngine.Events;

    [RequireComponent( typeof( Collider ) )]
    public class CustomButton_World : CustomButtonBase {
        [Header("Params")]
        public SelectMode selectMode;
        public DeselectMode deselectMode;
        public ClickMode clickMode;

        [Header("Events")]
        public UnityEvent onMouseEnter;
        public UnityEvent onMouseExit;
        public UnityEvent onMouseDown;
        public UnityEvent onMouseUp;
        public UnityEvent onButtonClick;

        private void OnMouseEnter () {
            if ( !active )
                return;
            if ( !selected ) {
                if ( selectMode == SelectMode.MouseEnter )
                    Select();
            }
            onMouseEnter.Invoke();
        }

        private void OnMouseExit () {
            if ( !active )
                return;
            if ( selected ) {
                if ( clickMode == ClickMode.Drag ) {
                    Click();
                    onButtonClick.Invoke();
                }
                if ( deselectMode == DeselectMode.MouseExit )
                    Deselect();
            }
            onMouseExit.Invoke();
        }

        private void OnMouseDown () {
            if ( !active )
                return;
            if ( selected ) {
                if ( clickMode == ClickMode.Down ) {
                    Click();
                    onButtonClick.Invoke();
                }
            }
            else {
                if ( selectMode == SelectMode.MouseDown )
                    Select();
            }
            onMouseDown.Invoke();
        }

        private void OnMouseUp () {
            if ( !active )
                return;
            if ( selected && clickMode == ClickMode.Up ) {
                Click();
                onButtonClick.Invoke();
            }
            onMouseUp.Invoke();
        }
    }
}
namespace Deirin.CustomButton {
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.EventSystems;

    public class CustomButton_Canvas : CustomButtonBase, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, IPointerDownHandler {
        [Header("Params")]
        public SelectMode selectMode;
        public DeselectMode deselectMode;
        public ClickMode clickMode;

        [Header("Events")]
        public UnityEvent OnMouseEnter;
        public UnityEvent OnMouseExit;
        public UnityEvent OnMouseDown;
        public UnityEvent OnMouseUp;
        public UnityEvent OnButtonClick;

        public void OnPointerDown ( PointerEventData eventData ) {
            if ( !active )
                return;
            if ( selected ) {
                if ( clickMode == ClickMode.Down ) {
                    Click();
                    OnButtonClick?.Invoke();
                }
            }
            else {
                if ( selectMode == SelectMode.MouseDown )
                    Select();
            }
            OnMouseDown?.Invoke();
        }

        public void OnPointerEnter ( PointerEventData eventData ) {
            if ( !active )
                return;
            if ( !selected ) {
                if ( selectMode == SelectMode.MouseEnter )
                    Select();
            }
            OnMouseEnter?.Invoke();
        }

        public void OnPointerExit ( PointerEventData eventData ) {
            if ( !active )
                return;
            if ( selected ) {
                if ( clickMode == ClickMode.Drag ) {
                    Click();
                    OnButtonClick?.Invoke();
                }
                if ( deselectMode == DeselectMode.MouseExit )
                    Deselect();
            }
            OnMouseExit?.Invoke();
        }

        public void OnPointerUp ( PointerEventData eventData ) {
            if ( !active )
                return;
            if ( selected && clickMode == ClickMode.Up ) {
                Click();
                OnButtonClick.Invoke();
            }
            OnMouseUp?.Invoke();
        }
    }
}
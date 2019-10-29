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
        public UnityEvent OnMouseClick;

        public void OnPointerDown ( PointerEventData eventData ) {
            if ( selected ) {
                if ( clickMode == ClickMode.Down )
                    OnMouseClick?.Invoke();
            }
            else {
                if ( selectMode == SelectMode.MouseDown )
                    Select();
            }
            OnMouseDown?.Invoke();
        }

        public void OnPointerEnter ( PointerEventData eventData ) {
            if ( !selected ) {
                if ( selectMode == SelectMode.MouseEnter )
                    Select();
            }
            OnMouseEnter?.Invoke();
        }

        public void OnPointerExit ( PointerEventData eventData ) {
            if ( selected ) {
                if ( deselectMode == DeselectMode.MouseExit )
                    Deselect();
            }
            OnMouseExit?.Invoke();
        }

        public void OnPointerUp ( PointerEventData eventData ) {
            if ( selected && clickMode == ClickMode.Up )
                OnMouseClick?.Invoke();
            OnMouseUp?.Invoke();
        }
    }
}
namespace Deirin.CustomButton {
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.EventSystems;

    public class CustomButton_Canvas : CustomButtonBase, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, IPointerDownHandler {
        [Header("Params")]
        public ClickMode clickMode;

        [Header("Events")]
        public UnityEvent OnMouseEnter, OnMouseExit, OnMouseDown, OnMouseUp, OnMouseClick;

        public void OnPointerDown ( PointerEventData eventData ) {
            if ( selected && clickMode == ClickMode.Down )
                OnMouseClick?.Invoke();
            else
                OnMouseDown?.Invoke();
        }

        public void OnPointerEnter ( PointerEventData eventData ) {
            OnMouseEnter?.Invoke();
        }

        public void OnPointerExit ( PointerEventData eventData ) {
            OnMouseExit?.Invoke();
        }

        public void OnPointerUp ( PointerEventData eventData ) {
            if ( selected && clickMode == ClickMode.Up )
                OnMouseClick?.Invoke();
            OnMouseUp?.Invoke();
        }
    }
}
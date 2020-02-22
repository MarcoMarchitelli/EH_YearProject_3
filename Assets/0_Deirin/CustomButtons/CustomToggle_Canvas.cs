namespace Deirin.CustomButton {
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.EventSystems;

    public class CustomToggle_Canvas : CustomButtonBase, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, IPointerDownHandler {
        [Header("Params")]
        public MouseInteraction onInteraction;
        public MouseInteraction offInteraction;

        [Header("Events")]
        public UnityEvent On;
        public UnityEvent Off;
        public UnityEvent MouseEnter;
        public UnityEvent MouseExit;

        [SerializeField] bool on;

        public void OnPointerDown ( PointerEventData eventData ) {
            if ( active == false )
                return;
            if ( onInteraction == MouseInteraction.Down && !on ) {
                on = true;
                On.Invoke();
            }
            else
            if ( offInteraction == MouseInteraction.Down && on ) {
                on = false;
                Off.Invoke();
            }
        }

        public void OnPointerEnter ( PointerEventData eventData ) {
            if ( active == false )
                return;
            if ( onInteraction == MouseInteraction.Enter && !on ) {
                on = true;
                On.Invoke();
            }
            else
            if ( offInteraction == MouseInteraction.Enter && on ) {
                on = false;
                Off.Invoke();
            }
            MouseEnter.Invoke();
        }

        public void OnPointerExit ( PointerEventData eventData ) {
            if ( active == false )
                return;
            if ( onInteraction == MouseInteraction.Exit && !on ) {
                on = true;
                On.Invoke();
            }
            else
            if ( offInteraction == MouseInteraction.Exit && on ) {
                on = false;
                Off.Invoke();
            }
            MouseExit.Invoke();
        }

        public void OnPointerUp ( PointerEventData eventData ) {
            if ( active == false )
                return;
            if ( onInteraction == MouseInteraction.Up && !on ) {
                on = true;
                On.Invoke();
            }
            else
            if ( offInteraction == MouseInteraction.Up && on ) {
                on = false;
                Off.Invoke();
            }
        }

        public void SetOn ( bool value ) {
            on = value;
            if ( on == true )
                On.Invoke();
            else
                Off.Invoke();
        }
    }
}
namespace Deirin.Utilities {
    using UnityEngine;
    using UnityEngine.Events;

    public class KeyListener : MonoBehaviour {
        public enum InputType { Down, Up, Hold }

        public KeyData[] Keys;

        private void Update () {
            foreach ( var item in Keys ) {
                switch ( item.inputType ) {
                    case InputType.Down:
                    if ( Input.GetKeyDown( item.key ) ) {
                        item.CallBack.Invoke();
                    }
                    break;
                    case InputType.Up:
                    if ( Input.GetKeyUp( item.key ) ) {
                        item.CallBack.Invoke();
                    }
                    break;
                    case InputType.Hold:
                    if ( Input.GetKey( item.key ) ) {
                        item.CallBack.Invoke();
                    }
                    break;
                }
            }
        }

        [System.Serializable]
        public class KeyData {
            public KeyCode key;
            public InputType inputType;
            public UnityEvent CallBack;
        }
    }
}
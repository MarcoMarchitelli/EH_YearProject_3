using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour {
    public InputKeyEvent[] keyInputEvents;

    private void Update () {
        ReadKeyInputs();
    }

    private void ReadKeyInputs () {
        for ( int i = 0; i < keyInputEvents.Length; i++ ) {
            switch ( keyInputEvents[i].data.interaction ) {
                case InputKeyEventData.InteractionType.Down:
                if ( Input.GetKeyDown( keyInputEvents[i].data.keyCode ) )
                    keyInputEvents[i].onInput.Invoke();
                break;
                case InputKeyEventData.InteractionType.Up:
                if ( Input.GetKeyUp( keyInputEvents[i].data.keyCode ) )
                    keyInputEvents[i].onInput.Invoke();
                break;
                case InputKeyEventData.InteractionType.Hold:
                if ( Input.GetKey( keyInputEvents[i].data.keyCode ) )
                    keyInputEvents[i].onInput.Invoke();
                break;
            }
        }
    }
}

[System.Serializable]
public class InputKeyEvent {
    public InputKeyEventData data;
    public UnityEvent onInput;
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( menuName = "Input/Key Event" )]
public class InputKeyEventData : InputEventData {
    public enum InteractionType { Down, Up, Hold }

    public string ID;
    public KeyCode keyCode;
    public InteractionType interaction;
}
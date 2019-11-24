using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class CustomUnityEvents {

}

[System.Serializable]
public class UnityStringEvent : UnityEvent<string> { }

[System.Serializable]
public class UnityComponentEvent : UnityEvent<Component> { }
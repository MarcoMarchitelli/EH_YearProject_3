using UnityEngine;
using UnityEngine.Events;
using TotemTD;

public static class CustomUnityEvents {

}

[System.Serializable]
public class UnityStringEvent : UnityEvent<string> { }

[System.Serializable]
public class UnityComponentEvent : UnityEvent<Component> { }

[System.Serializable]
public class UnityTurretEvent : UnityEvent<TurretModule> { }

[System.Serializable]
public class UnityVector3ArrayEvent : UnityEvent<Vector3[]> { }
namespace Deirin.Utilities {
    using UnityEngine;
    using UnityEngine.Events;
    using Deirin.EB;

    public static class CustomUnityEvents {

    }

    [System.Serializable]
    public class UnityFloatEvent : UnityEvent<float> { }

    [System.Serializable]
    public class UnityIntEvent : UnityEvent<int> { }

    [System.Serializable]
    public class UnityStringEvent : UnityEvent<string> { }

    [System.Serializable]
    public class UnityBoolEvent : UnityEvent<bool> { }

    [System.Serializable]
    public class UnityComponentEvent : UnityEvent<Component> { }

    [System.Serializable]
    public class UnityVector3ArrayEvent : UnityEvent<Vector3[]> { }

    [System.Serializable]
    public class UnityColorEvent : UnityEvent<Color> { }

    [System.Serializable]
    public class UnityEntityEvent : UnityEvent<BaseEntity> { }

    [System.Serializable]
    public class UnityBehaviourEvent : UnityEvent<BaseBehaviour> { }
}
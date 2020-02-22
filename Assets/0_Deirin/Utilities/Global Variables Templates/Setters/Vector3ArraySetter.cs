namespace Deirin.Utilities {
    using UnityEngine;

    public class Vector3ArraySetter : MonoBehaviour {
        public Vector3ArrayVariable variable;

        public void Set ( Vector3[] value ) {
            variable.Value = value;
        }
    }
}
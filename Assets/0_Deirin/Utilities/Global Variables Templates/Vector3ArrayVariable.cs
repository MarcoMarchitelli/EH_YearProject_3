using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Vector3ArrayVariable : ScriptableObject {
    [SerializeField] Vector3[] value;

    public Vector3[] Value { get => value; set { this.value = value; OnValueChanged?.Invoke( Value ); } }
    public System.Action<Vector3[]> OnValueChanged;
}
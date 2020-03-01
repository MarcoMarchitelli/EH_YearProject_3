using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( menuName = "Deirin/Global Variables/Float" )]
public class FloatVariable : ScriptableObject {
    [SerializeField] float value;

    public float Value { get => value; set { this.value = value; OnValueChanged?.Invoke( Value ); } }
    public System.Action<float> OnValueChanged;

    private void OnValidate () {
        OnValueChanged?.Invoke( Value );
    }
}
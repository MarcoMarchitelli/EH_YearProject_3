using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( menuName = "Deirin/Global Variables/Bool" )]
public class BoolVariable : ScriptableObject {
    [SerializeField] bool value;

    public bool Value { get => value; set { this.value = value; OnValueChanged?.Invoke( Value ); } }
    public System.Action<bool> OnValueChanged;

    private void OnValidate () {
        OnValueChanged?.Invoke( Value );
    }
}
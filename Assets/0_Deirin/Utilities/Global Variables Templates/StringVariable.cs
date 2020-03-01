using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( menuName = "Deirin/Global Variables/String" )]
public class StringVariable : ScriptableObject {
    [SerializeField] string value;

    public string Value { get => value; set { this.value = value; OnValueChanged?.Invoke( Value ); } }
    public System.Action<string> OnValueChanged;

    private void OnValidate () {
        OnValueChanged?.Invoke( Value );
    }
}
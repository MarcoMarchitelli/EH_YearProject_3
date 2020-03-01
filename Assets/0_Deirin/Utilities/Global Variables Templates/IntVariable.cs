using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( menuName = "Deirin/Global Variables/Int" )]
public class IntVariable : ScriptableObject {
    [SerializeField] int value;

    public int Value { get => value; set { this.value = value; OnValueChanged?.Invoke( Value ); } }
    public System.Action<int> OnValueChanged;

    private void OnValidate () {
        OnValueChanged?.Invoke( Value );
    }
}
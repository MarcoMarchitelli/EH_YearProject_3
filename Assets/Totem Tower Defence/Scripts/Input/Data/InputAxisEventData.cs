using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Input/Axis Event")]
public class InputAxisEventData : InputEventData {
    public enum ComparisonType { equals, greater, lower }

    public string ID;
    public string axisName;
    public float referenceValue;
    public ComparisonType comparison;
    public bool callOnce;

    public bool called;
}
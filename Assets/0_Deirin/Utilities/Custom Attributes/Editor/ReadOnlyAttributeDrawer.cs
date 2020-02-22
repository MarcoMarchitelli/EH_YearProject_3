using UnityEngine;
using UnityEditor;
using Deirin.Utilities;

[CustomPropertyDrawer( typeof( ReadOnlyAttribute ) )]
public class ReadOnlyAttributeDrawer : PropertyDrawer {
    public override void OnGUI ( Rect position, SerializedProperty property, GUIContent label ) {
        EditorGUI.BeginDisabledGroup(true);
        EditorGUI.PropertyField( position, property, label );
        EditorGUI.EndDisabledGroup();
    }
}
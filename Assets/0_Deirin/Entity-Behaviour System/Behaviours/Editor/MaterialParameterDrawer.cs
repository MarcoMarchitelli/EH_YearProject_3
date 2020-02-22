namespace Deirin.EB {
    using UnityEngine;
    using UnityEditor;

    //[CustomPropertyDrawer( typeof( MaterialParameter ) )]
    public class MaterialParameterDrawer : PropertyDrawer {
        public override void OnGUI ( Rect position, SerializedProperty property, GUIContent label ) {
            label = EditorGUI.BeginProperty( position, label, property );
            EditorGUI.PrefixLabel( position, label );
            EditorGUI.indentLevel++;

            SerializedProperty type = property.FindPropertyRelative( "type" );
            position.y += 16f;
            EditorGUI.PropertyField( position, type );

            position.y += 16f;
            EditorGUI.PropertyField( position, property.FindPropertyRelative( "name" ) );

            position.y += 16f;
            switch ( type.enumValueIndex ) {
                case 0:
                EditorGUI.PropertyField( position, property.FindPropertyRelative( "colorValue" ) );
                break;
                case 1:
                EditorGUI.PropertyField( position, property.FindPropertyRelative( "floatValue" ) );
                break;
                case 2:
                EditorGUI.PropertyField( position, property.FindPropertyRelative( "intValue" ) );
                break;
                case 3:
                EditorGUI.PropertyField( position, property.FindPropertyRelative( "vector4Value" ) );
                break;
            }

            EditorGUI.indentLevel--;
            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight ( SerializedProperty property, GUIContent label ) {
            return 16f * 4f;
        }
    }
}
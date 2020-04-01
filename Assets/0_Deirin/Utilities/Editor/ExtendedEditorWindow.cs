namespace Deirin.Utilities {
    using UnityEditor;

    public class ExtendedEditorWindow : EditorWindow {
        protected SerializedObject serializedObject;
        protected SerializedProperty currentProperty;

        protected void DrawProperties ( SerializedProperty property, bool drawChildren ) {
            string lastPropertyPath = string.Empty;
            foreach ( SerializedProperty p in property ) {
                if ( p.isArray && p.propertyType == SerializedPropertyType.Generic ) {
                    EditorGUILayout.BeginHorizontal();
                    p.isExpanded = EditorGUILayout.Foldout( p.isExpanded, p.displayName );
                    EditorGUILayout.EndHorizontal();

                    if ( p.isExpanded ) {
                        EditorGUI.indentLevel++;
                        DrawProperties( p, drawChildren );
                        EditorGUI.indentLevel--;
                    }
                }
                else {
                    if ( !string.IsNullOrEmpty( lastPropertyPath ) && p.propertyPath.Contains( lastPropertyPath ) )
                        continue;
                    lastPropertyPath = p.propertyPath;
                    EditorGUILayout.PropertyField( p, drawChildren );
                }
            }
        }
    }
}
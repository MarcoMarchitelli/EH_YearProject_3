using UnityEngine;
using UnityEditor;
using SweetRage;

[CustomEditor( typeof( LevelData ) )]
public class LevelDataEditor : Editor {
    private LevelData levelData;

    //private SerializedProperty wavesInfo;
    private SerializedProperty levelPrefab;

    private void OnEnable () {
        levelData = target as LevelData;

        //wavesInfo = serializedObject.FindProperty( "wavesInfo" );
        levelPrefab = serializedObject.FindProperty( "levelPrefab" );
    }

    public override void OnInspectorGUI () {
        serializedObject.Update();

        //EditorGUILayout.Space();
        //EditorGUILayout.Space();
        //EditorGUILayout.Space();

        //EditorGUILayout.PropertyField( wavesInfo, true );
        EditorGUILayout.PropertyField( levelPrefab, true );

        if ( GUILayout.Button( "Edit Level" ) ) {
            AssetDatabase.OpenAsset( levelData.levelPrefab );
        }

        serializedObject.ApplyModifiedProperties();
    }
}
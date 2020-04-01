using UnityEngine;
using UnityEditor;
using SweetRage;

[CustomEditor( typeof( LevelData ) )]
public class LevelDataEditor : Editor {
    private LevelData levelData;

    //private SerializedProperty wavesInfo;

    private void OnEnable () {
        levelData = target as LevelData;

        //wavesInfo = serializedObject.FindProperty( "wavesInfo" );
    }

    public override void OnInspectorGUI () {
        //EditorGUILayout.Space();
        //EditorGUILayout.Space();
        //EditorGUILayout.Space();

        //EditorGUILayout.PropertyField( wavesInfo, true );

        if ( GUILayout.Button( "Edit Level" ) ) {
            AssetDatabase.OpenAsset( levelData.levelPrefab );
        }
    }
}
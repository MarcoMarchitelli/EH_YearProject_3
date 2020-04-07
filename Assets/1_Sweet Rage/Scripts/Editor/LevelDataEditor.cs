using UnityEngine;
using UnityEditor;
using SweetRage;

[CustomEditor( typeof( LevelData ) )]
public class LevelDataEditor : Editor {
    private LevelData levelData;

    private void OnEnable () {
        levelData = target as LevelData;
    }

    public override void OnInspectorGUI () {
        base.OnInspectorGUI();

        if ( GUILayout.Button( "Edit Level" ) ) {
            AssetDatabase.OpenAsset( levelData.levelContainerPrefab );
        }
    }
}
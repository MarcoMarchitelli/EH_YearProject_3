using UnityEngine;
using UnityEditor;
using SweetRage;
using System.IO;

public class LevelCreationWindow : EditorWindow {
    //private static string LEVEL_PATH = "Assets/1_Totem Tower Defence/Data/Resources/Levels/";
    //private const string PREFAB_PATH = "Assets/1_Totem Tower Defence/Prefabs/Levels/";
    //private static LevelData levelData;

    //private static SerializedObject levelDataSerializedObject;

    //[MenuItem( "SweetRage/Create Level" )]
    //public static void Open () {
    //    GetWindow<LevelCreationWindow>( "Level Creation" );
    //    levelData = CreateInstance<LevelData>();
    //    levelDataSerializedObject = new SerializedObject( levelData );
    //}

    //public void CreateLevel ( LevelData level ) {
    //    if ( level != levelData )
    //        return;

    //    if ( AssetDatabase.IsValidFolder( LEVEL_PATH ) == false )
    //        Directory.CreateDirectory( LEVEL_PATH );
    //    AssetDatabase.CreateAsset( level, LEVEL_PATH + "level.asset" );

    //    GameObject go = new GameObject("Level Prefab");
    //    go.AddComponent<LevelEntity>();
    //    for ( int i = 0; i < levelData.wavesInfo.Length; i++ ) {
    //        GameObject waveGo = new GameObject("Wave_" + (i + 1).ToString());
    //        Wave wave = waveGo.AddComponent<Wave>();
    //        wave.modules = levelData.wavesInfo[i].modules;
    //        for ( int j = 0; j < levelData.wavesInfo[i].spawnerCount; j++ ) {
    //            GameObject spawnerGo = new GameObject("Spawner_" + (j + 1).ToString());
    //            spawnerGo.AddComponent<Spawner>();
    //            spawnerGo.transform.SetParent( waveGo.transform );
    //        }
    //        waveGo.transform.SetParent( go.transform );
    //    }

    //    if ( AssetDatabase.IsValidFolder( PREFAB_PATH ) == false )
    //        Directory.CreateDirectory( PREFAB_PATH );
    //    GameObject prefab = PrefabUtility.SaveAsPrefabAssetAndConnect( go, PREFAB_PATH + "level.prefab", InteractionMode.UserAction );
    //    DestroyImmediate( go );

    //    level.levelPrefab = prefab.GetComponent<LevelEntity>();

    //    AssetDatabase.SaveAssets();
    //}

    //private void OnGUI () {
    //    levelDataSerializedObject.Update();

    //    EditorGUILayout.Space();
    //    EditorGUILayout.Space();
    //    EditorGUI.indentLevel++;

    //    EditorGUILayout.PropertyField( levelDataSerializedObject.FindProperty( "wavesInfo" ), true );

    //    EditorGUILayout.Space();
    //    EditorGUILayout.Space();
    //    if ( GUILayout.Button( "Create" ) ) {
    //        CreateLevel( levelData );
    //    }

    //    EditorGUI.indentLevel--;

    //    levelDataSerializedObject.ApplyModifiedProperties();
    //}
}
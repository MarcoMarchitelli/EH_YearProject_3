using UnityEngine;
using UnityEditor;
using SweetRage;
using System.IO;

public class LevelCreationWindow : EditorWindow {
    private const string LEVEL_PATH = "Assets/1_Totem Tower Defence/Data/Levels/";
    private const string PREFAB_PATH = "Assets/1_Totem Tower Defence/Prefabs/Levels/";
    private static LevelData levelData;

    [SerializeField] private WaveInfo[] wavesInfo;

    [MenuItem( "SweetRage/Create Level" )]
    public static void Open () {
        GetWindow<LevelCreationWindow>( "Level Creation" );
        levelData = CreateInstance<LevelData>();
    }

    public void CreateLevel ( LevelData level ) {
        if ( level != levelData )
            return;

        if ( AssetDatabase.IsValidFolder( LEVEL_PATH ) == false )
            Directory.CreateDirectory( LEVEL_PATH );
        AssetDatabase.CreateAsset( level, LEVEL_PATH + "level.asset" );

        GameObject go = new GameObject("Level Prefab");
        go.AddComponent<LevelEntity>();
        for ( int i = 0; i < wavesInfo.Length; i++ ) {
            GameObject waveGo = new GameObject("Wave_" + (i + 1).ToString());
            Wave wave = waveGo.AddComponent<Wave>();
            wave.modules = wavesInfo[i].modules;
            waveGo.transform.SetParent( go.transform );
        }

        if ( AssetDatabase.IsValidFolder( PREFAB_PATH ) == false )
            Directory.CreateDirectory( PREFAB_PATH );
        GameObject prefab = PrefabUtility.SaveAsPrefabAssetAndConnect( go, PREFAB_PATH + "level.prefab", InteractionMode.UserAction );
        DestroyImmediate( go );

        level.levelPrefab = prefab.GetComponent<LevelEntity>();

        AssetDatabase.SaveAssets();
    }

    private void OnGUI () {
        SerializedObject so = new SerializedObject(this);
        so.Update();

        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUI.indentLevel++;

        EditorGUILayout.PropertyField( so.FindProperty( "wavesInfo" ), true );

        EditorGUILayout.Space();
        EditorGUILayout.Space();
        if ( GUILayout.Button( "Create" ) ) {
            CreateLevel( levelData );
        }

        EditorGUI.indentLevel--;

        so.ApplyModifiedProperties();
    }
}

[System.Serializable]
public class WaveInfo {
    [Min(0)] public float placementTime;
    [Min(0)] public int spawnerCount;
    public TurretModule[] modules;
}
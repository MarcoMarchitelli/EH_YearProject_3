using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SerializationManager {
    public static string saveFolderPath = Application.persistentDataPath + "/saves";

    public static bool Save ( string saveName, object saveData ) {
        BinaryFormatter formatter = GetBinaryFormatter();

        if ( !Directory.Exists( saveFolderPath ) ) {
            Directory.CreateDirectory( saveFolderPath );
        }

        string saveFilePath = saveFolderPath + "/" + saveName + ".save";

        FileStream file = File.Create(saveFilePath);
        formatter.Serialize( file, saveData );
        file.Close();

        return true;
    }

    public static object Load ( string path ) {
        if ( !File.Exists( path ) ) {
            return null;
        }

        BinaryFormatter formatter = GetBinaryFormatter();

        FileStream file = File.Open(path, FileMode.Open);

        try {
            object save = formatter.Deserialize(file);
            file.Close();
            return save;
        }
        catch {
#if UNITY_EDITOR
            Debug.LogError( "Failed to load file at: " + path );
#endif
            file.Close();
            return null;
        }
    }

#if UNITY_EDITOR
    [UnityEditor.MenuItem("Tools/Sweet Rage/Save System/Delete Saves")]
#endif
    public static void DeleteSaves () {
        if ( Directory.Exists( saveFolderPath ) ) {
            Directory.Delete( saveFolderPath, true );
        }
    }

    private static BinaryFormatter GetBinaryFormatter () {
        BinaryFormatter formatter = new BinaryFormatter();
        return formatter;
    }
}
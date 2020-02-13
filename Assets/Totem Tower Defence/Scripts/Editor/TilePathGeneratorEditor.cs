using UnityEngine;
using UnityEditor;

[CustomEditor( typeof( TilePathGenerator ) )]
public class TilePathGeneratorEditor : Editor {
    private TilePathGenerator tpg;

    private void OnEnable () {
        tpg = target as TilePathGenerator;
    }

    public override void OnInspectorGUI () {
        base.OnInspectorGUI();

        if ( GUILayout.Button( "Generate Path" ) ) {
            tpg.GeneratePath();
        }
    }
}
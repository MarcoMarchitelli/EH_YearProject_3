namespace TotemTD {
    using UnityEngine;
    using UnityEditor;

    [CustomEditor( typeof( Path ) )]
    public class PathEditor : Editor {
        Path p;

        private void OnEnable () {
            p = target as Path;
        }

        public override void OnInspectorGUI () {
            base.OnInspectorGUI();
            if ( GUILayout.Button( "Generate Mesh" ) )
                p.ConstructMesh();
            if ( GUILayout.Button( "Generate Fake Mesh" ) )
                p.ConstructFakeMesh();
        }
    }
}
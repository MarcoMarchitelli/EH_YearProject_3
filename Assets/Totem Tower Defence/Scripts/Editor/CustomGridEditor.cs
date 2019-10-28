namespace TotemTD {
    using UnityEngine;
    using UnityEditor;

    [CustomEditor( typeof( CustomGrid ) )]
    public class CustomGridEditor : Editor {
        CustomGrid g;

        private void OnEnable () {
            g = target as CustomGrid;
        }

        public override void OnInspectorGUI () {
            base.OnInspectorGUI();
            if ( GUILayout.Button( "Generate Grid" ) )
                g.GenerateGrid();
        }
    }
}
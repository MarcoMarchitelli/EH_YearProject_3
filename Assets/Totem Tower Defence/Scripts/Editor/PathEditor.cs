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
            if ( p.autoSetPoints )
                p.SetPoints();
            else if ( GUILayout.Button( "Set Points" ) )
                    p.SetPoints();
        }
    }
}
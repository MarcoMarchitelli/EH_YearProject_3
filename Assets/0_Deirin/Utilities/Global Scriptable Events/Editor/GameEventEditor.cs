namespace Deirin.Utilities {
    using UnityEngine;
    using UnityEditor;

    public class GameEventEditor : Editor {
        GameEvent g;

        private void OnEnable () {
            g = target as GameEvent;
        }

        public override void OnInspectorGUI () {
            if ( GUILayout.Button( "Invoke" ) )
                g.Invoke();
        }
    }
}
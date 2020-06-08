namespace Deirin.Tweeners {
    using UnityEngine;
    using UnityEditor;

    [CustomEditor( typeof( TweenersContainer ) )]
    [CanEditMultipleObjects]
    public class TweenersContainerEditor : Editor {
        private TweenersContainer tc;

        private void OnEnable () {
            tc = target as TweenersContainer;
        }

        public override void OnInspectorGUI () {
            base.OnInspectorGUI();

            serializedObject.Update();

            if ( tc.tweeners == null || tc.tweeners.Count <= 0 )
                EditorGUILayout.HelpBox( "No Tweeners Found!", MessageType.Warning );
            else
                EditorGUILayout.HelpBox( tc.tweeners.Count + " Tweeners Found!", MessageType.Info );

            if ( GUILayout.Button( "Fetch Tweeners In Children" ) ) {
                tc.FetchTweeners();
                EditorUtility.SetDirty( target );
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}
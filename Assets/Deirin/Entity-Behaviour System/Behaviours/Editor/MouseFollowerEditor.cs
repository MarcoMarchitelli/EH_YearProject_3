using UnityEditor;
using Deirin.EB;

[CustomEditor( typeof( MouseFollower ) )]
public class MouseFollowerEditor : Editor {
    MouseFollower mf;

    private void OnEnable () {
        mf = target as MouseFollower;
    }

    public override void OnInspectorGUI () {
        SerializedObject so = new SerializedObject(mf);
        so.Update();

        SerializedProperty target = so.FindProperty("target");
        SerializedProperty startFollowingOnSetup = so.FindProperty("startFollowingOnSetup");
        SerializedProperty useMainCam = so.FindProperty("useMainCam");
        SerializedProperty followMode = so.FindProperty("followMode");

        EditorGUILayout.PropertyField( target );
        EditorGUILayout.PropertyField( startFollowingOnSetup );
        EditorGUILayout.PropertyField( useMainCam );
        if ( !useMainCam.boolValue ) {
            SerializedProperty cam = so.FindProperty("cam");
            EditorGUILayout.PropertyField( cam );
        }
        EditorGUILayout.PropertyField( followMode );

        switch ( followMode.enumValueIndex ) {
            case ( int ) MouseFollower.FollowMode.PlaneCasting:
            EditorGUILayout.Space();
            EditorGUILayout.LabelField( "Parameters", EditorStyles.boldLabel );
            EditorGUILayout.PropertyField( so.FindProperty( "positionOffset" ) );
            EditorGUILayout.PropertyField( so.FindProperty( "planeCenter" ) );
            EditorGUILayout.PropertyField( so.FindProperty( "planeNormal" ) );
            break;
            case ( int ) MouseFollower.FollowMode.RayCasting:
            EditorGUILayout.Space();
            EditorGUILayout.LabelField( "Parameters", EditorStyles.boldLabel );
            EditorGUILayout.PropertyField( so.FindProperty( "positionOffset" ) );
            EditorGUILayout.PropertyField( so.FindProperty( "castMask" ) );
            EditorGUILayout.PropertyField( so.FindProperty( "rayMaxDistance" ) );
            break;
        }

        so.ApplyModifiedProperties();
    }
}
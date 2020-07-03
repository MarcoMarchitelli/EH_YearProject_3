using UnityEditor;
using Deirin.EB;

[CustomEditor( typeof( MouseFollower ) )]
public class MouseFollowerEditor : Editor {
    MouseFollower mf;

    SerializedProperty targetProp;
    SerializedProperty startFollowingOnSetup;
    SerializedProperty useMainCam;
    SerializedProperty followMode;
    SerializedProperty speed;
    SerializedProperty cam;
    SerializedProperty positionOffset;
    SerializedProperty planeCenter;
    SerializedProperty planeNormal;
    SerializedProperty castMask;
    SerializedProperty rayMaxDistance;

    private void OnEnable () {
        mf = target as MouseFollower;

        targetProp = serializedObject.FindProperty("target");
        startFollowingOnSetup = serializedObject.FindProperty("startFollowingOnSetup");
        useMainCam = serializedObject.FindProperty("useMainCam");
        followMode = serializedObject.FindProperty("followMode");
        speed = serializedObject.FindProperty("speed");
        cam = serializedObject.FindProperty( "cam" );
        positionOffset = serializedObject.FindProperty( "positionOffset" );
        planeCenter = serializedObject.FindProperty( "planeCenter" );
        planeNormal = serializedObject.FindProperty( "planeNormal" );
        castMask = serializedObject.FindProperty( "castMask" );
        rayMaxDistance = serializedObject.FindProperty( "rayMaxDistance" );
    }

    public override void OnInspectorGUI () {
        serializedObject.Update();

        EditorGUILayout.PropertyField( targetProp );
        EditorGUILayout.PropertyField( startFollowingOnSetup );
        EditorGUILayout.PropertyField( useMainCam );
        if ( !useMainCam.boolValue ) {
            EditorGUILayout.PropertyField( cam );
        }
        EditorGUILayout.PropertyField( followMode );
        EditorGUILayout.PropertyField( speed );

        switch ( followMode.enumValueIndex ) {
            case ( int ) MouseFollower.FollowMode.PlaneCasting:
            EditorGUILayout.Space();
            EditorGUILayout.LabelField( "Parameters", EditorStyles.boldLabel );
            EditorGUILayout.PropertyField( positionOffset );
            EditorGUILayout.PropertyField( planeCenter );
            EditorGUILayout.PropertyField( planeNormal );
            break;
            case ( int ) MouseFollower.FollowMode.RayCasting:
            EditorGUILayout.Space();
            EditorGUILayout.LabelField( "Parameters", EditorStyles.boldLabel );
            EditorGUILayout.PropertyField( positionOffset );
            EditorGUILayout.PropertyField( castMask );
            EditorGUILayout.PropertyField( rayMaxDistance );
            break;
        }

        serializedObject.ApplyModifiedProperties();
    }
}
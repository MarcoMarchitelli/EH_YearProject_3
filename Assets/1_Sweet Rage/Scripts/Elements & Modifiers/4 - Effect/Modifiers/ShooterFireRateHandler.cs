namespace SweetRage {
    using UnityEngine;
#if UNITY_EDITOR
    using UnityEditor;
#endif

    public class ShooterFireRateHandler : AbsShooterModifierHandler {
        public FireRateMod[] fireRates;

        private Shooter shooter;
        private FireRateMod currentFireRateMod;

        private void OnDestroy () {
            OnCurrentChargeIncreases.RemoveListener( ChargeChangeHandler );
            OnCurrentChargeDecreases.RemoveListener( ChargeChangeHandler );
        }

        protected override void CustomSetup () {
            base.CustomSetup();

            Entity.TryGetBehaviour( out shooter );

            if ( shooter ) {
                OnCurrentChargeIncreases.AddListener( ChargeChangeHandler );
                OnCurrentChargeDecreases.AddListener( ChargeChangeHandler );
            }
#if UNITY_EDITOR
            else {
                print( name + " could not find shooter" );
            }
#endif
        }

        private void ChargeChangeHandler ( int currentCharge ) {
            int count = fireRates.Length;
            if ( shooter )
                shooter.ResetFireRate();
            if ( currentCharge > 0 && count > 0 && count >= currentCharge ) {
                currentFireRateMod = fireRates[currentCharge - 1];
                if ( currentFireRateMod.buffMode == FireRateMod.BuffMode.Percentage )
                    shooter.SetFireRate( shooter.FireRate + shooter.FireRate * currentFireRateMod.percentBuff );
                else
                    shooter.SetFireRate( shooter.FireRate + currentFireRateMod.flatBuff );
            }
        }
    }

    [System.Serializable]
    public class FireRateMod {
        public enum BuffMode { Flat = 0, Percentage = 1 }
        public BuffMode buffMode;
        [Tooltip("Fire rate percent to add")]
        public float percentBuff = 0;
        [Tooltip("Frequenza di applicazione dei danni")]
        public float flatBuff = 0;
    }

#if UNITY_EDITOR
    //[CustomEditor( typeof( FireRateMod ) )]
    //public class FireRateModDrawer : Editor {
    //    private SerializedProperty buffMode;
    //    private SerializedProperty percentBuff;
    //    private SerializedProperty flatBuff;

    //    private void OnEnable () {
    //        buffMode = serializedObject.FindProperty( "buffMode" );
    //        percentBuff = serializedObject.FindProperty( "percentBuff" );
    //        flatBuff = serializedObject.FindProperty( "flatBuff" );
    //    }

    //    public override void OnInspectorGUI () {
    //        serializedObject.Update();

    //        EditorGUILayout.PropertyField( buffMode );

    //        switch ( buffMode.enumValueIndex ) {
    //            case 0:
    //            EditorGUILayout.PropertyField( flatBuff );
    //            break;
    //            case 1:
    //            EditorGUILayout.PropertyField( percentBuff );
    //            break;
    //        }

    //        serializedObject.ApplyModifiedProperties();
    //    }
    //}
#endif
}
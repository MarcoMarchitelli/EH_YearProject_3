namespace SweetRage {
    using Deirin.EB;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Events;


    public class EnemyIceHandler : AbsEnemyElementHandler {
        [Header("Ice Params"), Tooltip("Percentuale di riduzione del movimento"), Range(0, 1), Space]
        public float[] slows;

        private PathPatroller pathPatroller;

        //private void OnDisable () {
        //    OnCurrentChargeIncreases.RemoveListener( ChargeChangeHandler );
        //    OnCurrentChargeDecreases.RemoveListener( ChargeChangeHandler );
        //}

        //protected override void CustomSetup () {
        //    base.CustomSetup();

        //    Entity.TryGetBehaviour( out pathPatroller );

        //    OnCurrentChargeIncreases.AddListener( ChargeChangeHandler );
        //    OnCurrentChargeDecreases.AddListener( ChargeChangeHandler );
        //}

        private void ChargeChangeHandler ( int currentCharge ) {
            if ( !pathPatroller || slows.Length >= currentCharge )
                return;

            pathPatroller.ResetSpeed();
            pathPatroller.SetSpeed( pathPatroller.Speed - pathPatroller.Speed * slows[currentCharge - 1] );
        }
    }
}
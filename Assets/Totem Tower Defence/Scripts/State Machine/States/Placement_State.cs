namespace TotemTD {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Placement_State : Game_StateBase {
        public override void Enter () {
            context.phaseUI.SetTexts( "Placement Phase" );
            context.phaseUI.Play( .7f );

            context.turretMenu.Activate( true );
        }
    }
}
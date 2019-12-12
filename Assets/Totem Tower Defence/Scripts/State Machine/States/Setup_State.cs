namespace TotemTD {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Setup_State : Game_StateBase {
        public override void Enter () {
            context.phaseUI.Setup();
            context.turretMenu.SetTurrets( context.level.CurrentWave.turretModules );
        }
    }
}
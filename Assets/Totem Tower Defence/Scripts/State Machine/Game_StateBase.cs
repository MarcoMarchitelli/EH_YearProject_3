namespace TotemTD {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Deirin.StateMachine;

    public abstract class Game_StateBase : StateBase {
        protected GameContext context;

        protected override void CustomSetup () {
            context = data as GameContext;
        }
    }
}
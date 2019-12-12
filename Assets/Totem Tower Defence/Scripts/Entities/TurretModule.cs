namespace TotemTD {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public abstract class TurretModule : MonoBehaviour {
        public TurretModuleData data;

        #region State
        public enum State { InMenu, Selected, Placed }
        public State state;

        public void SetState ( State state ) {
            this.state = state;
        }

        public void SetState ( int state ) {
            this.state = ( State ) state;
        } 
        #endregion

        public void Setup ( TurretModuleData data ) {
            this.data = data;
            CustomSetup();
        }

        protected virtual void CustomSetup () {

        }
    }
}
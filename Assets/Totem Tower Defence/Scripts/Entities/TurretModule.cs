namespace TotemTD {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public abstract class TurretModule : MonoBehaviour {
        public enum State { InMenu, Selected, Placed }
        public State state;

        public void SetState ( State state ) {
            this.state = state;
        }

        public void SetState ( int state ) {
            this.state = ( State ) state;
        }
    } 
}
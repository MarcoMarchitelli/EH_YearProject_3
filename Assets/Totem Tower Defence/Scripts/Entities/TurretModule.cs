namespace TotemTD {
    using Deirin.EB;
    using UnityEngine.Events;

    public class TurretModule : BaseEntity {
        public enum ModuleType { shooter, element, modifier }
        public enum State { selected, placed, inMenu, preview }

        public ModuleType type;
        public State state;

        TurretContainer turretContainer;

        public void TurretContainerEnterHandler ( TurretContainer turretContainer ) {
            if ( state == State.selected ) {
                this.turretContainer = turretContainer; 
                turretContainer.Preview( this );
                state = State.preview;
            }
        }

        public void LeftMouseClickHandler () {
            if ( state == State.preview )
                turretContainer.AddModule( this );
        }
    }
    [System.Serializable]
    public class UnityTurretModuleEvent : UnityEvent<TurretModule> { }
}
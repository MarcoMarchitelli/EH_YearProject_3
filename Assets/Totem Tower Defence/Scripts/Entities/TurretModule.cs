namespace TotemTD {
    using Deirin.EB;
    using UnityEngine;
    using UnityEngine.Events;
    using Deirin.Utilities;

    public class TurretModule : BaseEntity {
        public enum ModuleType { shooter, element, modifier }
        public enum State { inMenu, selected, placed, preview }

        [Header("Parameters")]
        public ModuleType type;
        [ReadOnly] public State state;

        [Header("Events")]
        public UnityEvent OnCanBePlaced;
        public UnityEvent OnCannotBePlaced;
        public UnityEvent OnPlace;

        private TurretContainer turretContainer;

        protected override void CustomSetup () {
            SetState( State.selected );
        }

        #region Game Event Handlers
        public void TurretContainerEnterHandler ( TurretContainer turretContainer ) {
            if ( state == State.selected ) {
                this.turretContainer = turretContainer;
                if ( turretContainer.CanPlace( this ) ) {
                    turretContainer.Preview( this );
                    OnCanBePlaced.Invoke();
                    SetState( State.preview );
                }
                else {
                    OnCannotBePlaced.Invoke();
                }
            }
        }

        public void TurretContainerExitHandler ( TurretContainer turretContainer ) {
            if ( state == State.preview && this.turretContainer == turretContainer ) {
                SetState( State.selected );
                this.turretContainer.RemoveModule( this );
                this.turretContainer = null;
                OnCannotBePlaced.Invoke();
            }
        }

        public void LeftMouseClickHandler () {
            if ( state == State.preview ) {
                SetState( State.placed );
                OnPlace.Invoke();
            }
        }
        #endregion

        #region API
        public void SetState ( State state ) {
            this.state = state;
        }

        public void SetState ( int state ) {
            this.state = ( State ) state;
        }
        #endregion
    }
    [System.Serializable]
    public class UnityTurretModuleEvent : UnityEvent<TurretModule> { }
}
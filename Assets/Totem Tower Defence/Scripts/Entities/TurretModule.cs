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

        [Header("Gameplay State Events")]
        public UnityEvent OnCanBePlaced;
        public UnityEvent OnCannotBePlaced;
        public UnityEvent OnPlace;
        [Tooltip("Called when releasing left mouse while not being placeable.")]
        public UnityTurretModuleEvent OnDeselection;
        public UnityEvent OnDeplacement;
        [Header("Mouse Interaction Events")]
        public UnityEvent OnMouseEnter;
        public UnityEvent OnMouseExit;
        public UnityEvent OnMouseDown;
        public UnityEvent OnMouseUp;

        private TurretContainer turretContainer;
        private bool mouseEntered, mouseDowned;

        public System.Action OnTurretContainerEnter, OnTurretContainerExit, OnLeftMouseUp;

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

        public void LeftMouseUpHandler () {
            if ( state == State.preview ) {
                SetState( State.placed );
                OnPlace.Invoke();
            }
            else if ( state == State.selected ) {
                OnDeselection.Invoke( this );
            }
        }

        public void ModuleEnterHandler ( TurretModule module ) {
            if ( state == State.placed && module == this )
                OnMouseEnter.Invoke();
        }

        public void ModuleExitHandler ( TurretModule module ) {
            if ( state == State.placed && module == this ) {
                if ( mouseDowned )
                    OnDeplacement.Invoke();
                mouseDowned = false;
                OnMouseExit.Invoke();
            }
        }

        public void ModuleDownHandler ( TurretModule module ) {
            if ( state == State.placed && module == this ) {
                mouseDowned = true;
                OnMouseDown.Invoke();
            }
        }

        public void ModuleUpHandler ( TurretModule module ) {
            if ( state == State.placed && module == this ) {
                mouseDowned = false;
                OnMouseUp.Invoke();
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
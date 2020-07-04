namespace SweetRage {
    using Deirin.EB;
    using UnityEngine;
    using UnityEngine.Events;
    using Deirin.Utilities;

    public class TurretModule : BaseEntity {
        public enum State { inMenu, selected, placed, preview }

        [ReadOnly] public State state;

        [Header("Data")]
        public TurretType turretType;

        [Header("References")]
        public Transform graphics;
        [Tooltip("The point in which the next module will be stacked in the turret container.")]
        public Transform topModuleSpot;

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
        [Header("Game State Events")]
        public UnityEvent OnWaveStartWhilePlaced;
        public UnityEvent OnWaveEndWhilePlaced;

        private TurretContainer turretContainer;
        private bool mouseEntered, mouseDowned;

        public System.Action OnTurretContainerEnter, OnTurretContainerExit, OnLeftMouseUp;

        public MouseFollower mouseFollower;

        protected override void CustomSetup () {
            SetState( State.inMenu );
        }

        private void Deplace () {
            turretContainer.RemoveModule( this );
            SetState( State.selected );
            OnDeplacement.Invoke();
        }

        #region Game Event Handlers
        public void TurretContainerEnterHandler ( TurretContainer turretContainer ) {
            //if this module is selected
            if ( state == State.selected ) {
                this.turretContainer = turretContainer;
                //if we can place this module in this container => we go in preview state
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
            //if this module is in preview state AND the turret container we have exited is ours => we exit and go in selected state
            if ( state == State.preview && this.turretContainer == turretContainer ) {
                SetState( State.selected );
                this.turretContainer.RemoveModule( this );
                this.turretContainer = null;
                OnCannotBePlaced.Invoke();
            }
        }

        public void LeftMouseUpHandler () {
            //if this module is in preview state (almost placed) => we place it
            if ( state == State.preview ) {
                SetState( State.placed );
                turretContainer.AddModule( this );
                OnPlace.Invoke();
            }
            //if this module is selected => we deselect it
            else if ( state == State.selected ) {
                SetState( State.inMenu );
                OnDeselection.Invoke( this );
            }

            //if we registered down action
            if ( mouseDowned ) {
                mouseDowned = false;
                //if this module is placed => we call mouse up event
                if ( state == State.placed )
                    OnMouseUp.Invoke();
            }
        }

        public void LeftMouseDownHandler () {
            //if the game is paused => return
            if ( GameTimer.instance.Paused )
                return;

            //if this module is being touched
            if ( mouseEntered ) {
                //if this module is placed => we register down action
                if ( state == State.placed ) {
                    mouseDowned = true;
                    OnMouseDown.Invoke();
                }
            }
        }

        public void ModuleEnterHandler ( TurretModule module ) {
            //if the mouse is in grab state (so we have a module selected already) => return
            if ( CursorState.instance.state == CursorState.State.Grab )
                return;
            //if this module is placed
            if ( state == State.placed ) {
                //if the touched module is this => register
                if ( module == this ) {
                    mouseEntered = true;
                    OnMouseEnter.Invoke();
                }
                //if it is another module AND we were touched => we are not touched anymore
                else if ( mouseEntered ) {
                    mouseEntered = false;
                    OnMouseExit.Invoke();
                }
            }
        }

        public void ModuleExitHandler ( TurretModule module ) {
            //if this module is placed AND this module is the one being touched => we exit
            if ( state == State.placed && module == this ) {
                OnMouseExit.Invoke();
                if ( mouseDowned )
                    Deplace();
                mouseDowned = false;
                mouseEntered = false;
            }
        }

        public void WaveStartHandler () {
            if ( state == State.placed ) {
                OnWaveStartWhilePlaced.Invoke();
            }
        }

        public void WaveEndHandler () {
            if ( state == State.placed ) {
                OnWaveEndWhilePlaced.Invoke();
            }
        }
        #endregion

        #region API
        public void SetState ( State state ) {
            this.state = state;
        }
        #endregion
    }

    [System.Serializable]
    public class UnityTurretModuleEvent : UnityEvent<TurretModule> { }
}
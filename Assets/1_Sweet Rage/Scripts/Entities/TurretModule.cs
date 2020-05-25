namespace SweetRage {
    using Deirin.EB;
    using UnityEngine;
    using UnityEngine.Events;
    using Deirin.Utilities;

    public class TurretModule : BaseEntity {
        public enum State { inMenu, selected, placed, preview }

        [ReadOnly]public State state;

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

        private TurretContainer turretContainer;
        private bool mouseEntered, mouseDowned;

        public System.Action OnTurretContainerEnter, OnTurretContainerExit, OnLeftMouseUp;

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
                SetState( State.inMenu );
                OnDeselection.Invoke( this );
            }

            if ( mouseDowned ) {
                if ( state == State.placed ) {
                    mouseDowned = false;
                    OnMouseUp.Invoke();
                }
            }
        }

        public void LeftMouseDownHandler () {
            if ( mouseEntered ) {
                if ( state == State.placed ) {
                    mouseDowned = true;
                    OnMouseDown.Invoke();
                }
            }
        }

        public void ModuleEnterHandler ( TurretModule module ) {
            if ( CursorState.instance.state == CursorState.State.Grab )
                return;
            if ( state == State.placed ) {
                if ( module == this ) {
                    mouseEntered = true;
                    OnMouseEnter.Invoke();
                }
                else if ( mouseEntered ) {
                    mouseEntered = false;
                    OnMouseExit.Invoke();
                }
            }
        }

        public void ModuleExitHandler ( TurretModule module ) {
            if ( state == State.placed && module == this ) {
                OnMouseExit.Invoke();
                if ( mouseDowned )
                    Deplace();
                mouseDowned = false;
                mouseEntered = false;
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
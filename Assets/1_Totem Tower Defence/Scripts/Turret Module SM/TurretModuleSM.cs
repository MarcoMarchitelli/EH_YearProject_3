namespace SweetRage {
    using Deirin.StateMachine;

    public class TurretModuleSM : StateMachineBase {
        public TurretModuleSMContext context;

        protected override void CustomDataSetup () {
            data = context;
            context.OnNext     += Next;
            context.OnInMenu   += InMenu;
            context.OnPlaced   += Placed;
            context.OnSelected += Selected;
        }

        private void OnDisable () {
            context.OnNext     -= Next;
            context.OnInMenu   -= InMenu;
            context.OnPlaced   -= Placed;
            context.OnSelected -= Selected;
        }

        public void Next () {
            animator.SetTrigger( "Next" );
        }

        public void Selected () {
            animator.SetTrigger( "Selected" );
        }

        public void InMenu () {
            animator.SetTrigger( "InMenu" );
        }
        
        public void Placed () {
            animator.SetTrigger( "Placed" );
        }
    }

    [System.Serializable]
    public class TurretModuleSMContext : IStateMachineData {
        public System.Action OnNext;
        public System.Action OnSelected;
        public System.Action OnInMenu;
        public System.Action OnPlaced;
        public void Next () {
            OnNext?.Invoke();
        }
        public void Selected () {
            OnSelected?.Invoke();
        }
        public void InMenu () {
            OnInMenu?.Invoke();
        }
        public void Placed () {
            OnPlaced?.Invoke();
        }
    }
}
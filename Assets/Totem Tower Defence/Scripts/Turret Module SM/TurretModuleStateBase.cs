namespace TotemTD {
    using Deirin.StateMachine;

    public class TurretModuleStateBase : StateBase {
        protected TurretModuleSMContext context;

        protected override void CustomSetup () {
            context = data as TurretModuleSMContext;
        }
    }
}
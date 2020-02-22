namespace TotemTD {
    using Deirin.EB;

    public abstract class Element : BaseBehaviour {
        public void Apply ( ElementStatusHandler target ) {
            target.Apply( this );
            CustomApply();
        }

        protected virtual void CustomApply () {

        }
    } 
}
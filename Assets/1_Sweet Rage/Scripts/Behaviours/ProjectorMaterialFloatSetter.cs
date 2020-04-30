namespace SweetRage {
    using UnityEngine;
    using Deirin.EB;

    public class ProjectorMaterialFloatSetter : BaseBehaviour {
        [Header("References")]
        public Projector projector;

        [Header("Parameters")]
        public string propertyName;
        public float[] values;
        public float valueMultiplier;
        public bool useFirstValueAtStart;

        private Material runtimeMat;
        private int propID;

        protected override void CustomSetup () {
            propID = Shader.PropertyToID( propertyName );
            runtimeMat = new Material( projector.material );
            projector.material = runtimeMat;
            if ( useFirstValueAtStart )
                SetValue( values[0] );
        }

        public void SetValue ( float value ) {
            runtimeMat.SetFloat( propID, value * valueMultiplier );
        }

        public void SetValue ( int valueIndex ) {
            runtimeMat.SetFloat( propID, values[valueIndex] * valueMultiplier );
        }
    }
}
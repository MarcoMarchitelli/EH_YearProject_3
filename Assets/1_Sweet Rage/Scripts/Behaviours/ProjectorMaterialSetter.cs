namespace SweetRage {
    using UnityEngine;
    using Deirin.EB;

    public class ProjectorMaterialSetter : BaseBehaviour {
        [Header("References")]
        public Projector projector;

        [Header("Float")]
        public string valuePropertyName;
        public float[] values;
        public float valueMultiplier;
        public bool useFirstValueAtStart;

        [Header("Material")]
        public string colorPropertyName;
        public Color[] colors;
        public bool useFirstColorAsStart;

        private Material runtimeMat;
        private int colorPropID, valuePropID;

        protected override void CustomSetup () {
            colorPropID = Shader.PropertyToID( colorPropertyName );
            valuePropID = Shader.PropertyToID( valuePropertyName );

            runtimeMat = new Material( projector.material );
            projector.material = runtimeMat;

            if ( useFirstValueAtStart )
                SetValue( values[0] );
            if ( useFirstColorAsStart )
                SetColor( colors[0] );
        }

        public void SetValue ( float value ) {
            runtimeMat.SetFloat( valuePropID, value * valueMultiplier );
        }

        public void SetValue ( int valueIndex ) {
            runtimeMat.SetFloat( valuePropID, values[valueIndex] * valueMultiplier );
        }

        public void SetColor ( Color color ) {
            runtimeMat.SetColor( colorPropID, color );
        }

        public void SetColor ( int colorIndex ) {
            runtimeMat.SetColor( colorPropID, colors[colorIndex] );
        }
    }
}
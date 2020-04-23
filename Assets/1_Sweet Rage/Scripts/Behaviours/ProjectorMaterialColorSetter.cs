namespace SweetRage {
    using UnityEngine;
    using Deirin.EB;

    public class ProjectorMaterialColorSetter : BaseBehaviour {
        [Header("References")]
        public Projector projector;

        [Header("Parameters")]
        public string propertyName;
        public Color[] colors;
        public bool useFirstColorAsStart;

        private Material runtimeMat;
        private int propID;

        protected override void CustomSetup () {
            propID = Shader.PropertyToID( propertyName );
            runtimeMat = new Material( projector.material );
            projector.material = runtimeMat;
            if ( useFirstColorAsStart )
                SetColor( colors[0] );
        }

        public void SetColor ( Color color ) {
            runtimeMat.SetColor( propID, color );
        }

        public void SetColor ( int colorIndex ) {
            runtimeMat.SetColor( propID, colors[colorIndex] );
        }
    }
}
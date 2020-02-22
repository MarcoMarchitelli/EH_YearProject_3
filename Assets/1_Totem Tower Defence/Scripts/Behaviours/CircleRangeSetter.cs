namespace TotemTD {
    using UnityEngine;
    using Deirin.EB;

    public class CircleRangeSetter : BaseBehaviour {
        [Header("References")]
        public Renderer circleRange;
        public Renderer circleRangeBorder;

        [Header("Parameters")]
        public Color[] colors;
        public bool useFirstColorAsStart;

        private MaterialPropertyBlock circleRangeMpb, circleRangeBorderMpb;

        protected override void CustomSetup () {
            circleRangeMpb = new MaterialPropertyBlock();
            circleRangeBorderMpb = new MaterialPropertyBlock();
            if ( useFirstColorAsStart )
                SetColor( colors[0] );
        }

        public void SetColor ( Color color ) {
            circleRangeMpb.SetColor( "_Color", color );
            circleRangeBorderMpb.SetColor( "_Color", color );

            circleRange.SetPropertyBlock( circleRangeMpb );
            circleRangeBorder.SetPropertyBlock( circleRangeBorderMpb );
        }

        public void SetColor ( int colorIndex ) {
            circleRangeMpb.SetColor( "_Color", colors[colorIndex] );
            circleRangeBorderMpb.SetColor( "_Color", colors[colorIndex] );

            circleRange.SetPropertyBlock( circleRangeMpb );
            circleRangeBorder.SetPropertyBlock( circleRangeBorderMpb );
        }
    }
}
namespace TotemTD {
    using UnityEngine;
    using Deirin.EB;

    public class CircleRangeSetter : BaseBehaviour {
        [Header("Refs")]
        public Renderer circleRange;
        public Renderer circleRangeBorder;
        public bool useStartColor;
        public Color startColor;

        private MaterialPropertyBlock circleRangeMpb, circleRangeBorderMpb;

        public override void OnAwake () {
            circleRangeMpb = new MaterialPropertyBlock();
            circleRangeBorderMpb = new MaterialPropertyBlock();
            if ( useStartColor )
                SetColor( startColor );
        }

        public void SetColor ( Color color ) {
            circleRangeMpb.SetColor( "_Color", color );
            circleRangeBorderMpb.SetColor( "_Color", color );

            circleRange.SetPropertyBlock( circleRangeMpb );
            circleRangeBorder.SetPropertyBlock( circleRangeBorderMpb );
        }
    }
}
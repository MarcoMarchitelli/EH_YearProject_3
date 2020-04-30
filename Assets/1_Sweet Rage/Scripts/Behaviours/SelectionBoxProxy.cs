namespace SweetRage {
    using UnityEngine;
    using Deirin.EB;
    using DG.Tweening;

    public class SelectionBoxProxy : BaseBehaviour {
        [Header("Params")]
        public Color targetColor;
        public float duration;
        public Ease ease;

        [Header("Refs")]
        public MeshRenderer mr;

        private int colorID;
        private Color startColor;
        private MaterialPropertyBlock mpb;

        protected override void CustomSetup () {
            mpb = new MaterialPropertyBlock();

            colorID = Shader.PropertyToID( "_Color" );
            startColor = mr.material.GetColor( colorID );
        }

        private Color GetColorProperty () {
            return mpb.GetColor( colorID );
        }

        private void SetColorProperty ( Color value ) {
            mpb.SetColor( colorID, value );
            mr.SetPropertyBlock( mpb );
        }

        public void Play () {
            DOTween.To( GetColorProperty, SetColorProperty, targetColor, duration ).SetEase( ease );
        }

        public void Rewind () {
            DOTween.To( GetColorProperty, SetColorProperty, startColor, duration ).SetEase( ease );
        }
    }
}
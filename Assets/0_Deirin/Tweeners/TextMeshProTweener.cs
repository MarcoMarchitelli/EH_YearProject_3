namespace Deirin.Tweeners {
    using UnityEngine;
    using DG.Tweening;
    using TMPro;

    public class TextMeshProTweener : BaseTweener {
        [Header("Specific Params")]
        public TextMeshProUGUI target;
        public bool color;
        public Color targetColor;
        public bool text;
        [Multiline] public string targetText;

        private void SetText ( string value ) {
            target.text = value;
        }

        private string GetText () {
            return target.text;
        }

        protected override void AssignTween () {
            if ( text )
                tween = DOTween.To( GetText, SetText, targetText, duration );
            if ( color )
                tween = target.DOColor( targetColor, duration );
        }
    }
}
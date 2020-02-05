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
        public bool resetOnPlay = true;

        Color startColor;
        string startText;

        private void Awake () {
            SetStartVars();
        }

        private void SetStartVars () {
            startColor = target.color;
            startText = target.text;
        }

        private void SetText ( string value ) {
            target.text = value;
        }

        private string GetText () {
            return target.text;
        }

        public override void Rewind () {
            target.DOKill();
            OnRewind.Invoke();

            if ( text )
                DOTween.To( GetText, SetText, startText, duration ).SetEase( ease );
            if ( color )
                target.DOColor( startColor, duration ).SetEase( ease ).SetLoops( loops ).onComplete += () => OnRewindEnd.Invoke();
        }

        public override void Play () {
            target.DOKill();
            OnPlay.Invoke();

            if ( resetOnPlay == false )
                SetStartVars();

            if ( text )
                DOTween.To( GetText, SetText, targetText, duration ).SetEase( ease );
            if ( color )
                target.DOColor( targetColor, duration ).SetEase( ease ).SetLoops( loops ).onComplete += () => OnPlayEnd.Invoke();
        }

        public override void Stop () {
            target.DOKill();
            OnStop.Invoke();
        }
    }
}
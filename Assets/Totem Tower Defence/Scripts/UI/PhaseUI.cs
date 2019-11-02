namespace TotemTD {
    using UnityEngine;
    using UnityEngine.UI;
    using TMPro;
    using DG.Tweening;

    public class PhaseUI : MonoBehaviour {
        [Header("Refs")]
        public Image background;
        public TextMeshProUGUI waveText;
        public TextMeshProUGUI numberText;

        private Sequence s;

        public void Setup () {
            numberText.alpha = 0;
            waveText.alpha = 0;
            background.transform.localScale = new Vector3( 1, 0, 1 );
            background.color = Color.clear;
        }

        public void Play ( System.Action func = null ) {
            s = DOTween.Sequence();
            s.Append( background.DOFade( .9f, 1f ).SetEase( Ease.OutCubic ) );
            s.Join( background.transform.DOScaleY( 1, 1f ).SetEase( Ease.OutCubic ) );
            s.Append( waveText.DOFade( 1, .5f ) );
            s.Insert( 1.3f, numberText.DOFade( 1, .5f ) );
            s.onComplete += () => func?.Invoke();
        }

        public void Rewind ( System.Action func = null ) {
            s.PlayBackwards();
            s.onRewind += () => func?.Invoke();
        }

        public void SetWaveNumber ( int waveNumber ) {
            numberText.text = waveNumber.ToString();
        }
    }
}
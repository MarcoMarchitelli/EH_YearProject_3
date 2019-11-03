namespace TotemTD {
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using TMPro;
    using DG.Tweening;

    public class PhaseUI : MonoBehaviour {
        [Header("Refs")]
        public TextMeshProUGUI textPrefab;
        public Transform textsContainer;
        public Image background;

        private Sequence s;
        private List<TextMeshProUGUI> texts = new List<TextMeshProUGUI>();

        public void Setup () {
            background.transform.localScale = new Vector3( 1, 0, 1 );
            background.color = Color.clear;
        }

        public void Play ( System.Action func = null ) {
            s = DOTween.Sequence();
            s.Append( background.DOFade( .9f, 1f ).SetEase( Ease.OutCubic ) );
            s.Join( background.transform.DOScaleY( 1, 1f ).SetEase( Ease.OutCubic ) );
            s.Append( texts[0].DOFade( 1, .5f ) );
            for ( int i = 1; i < texts.Count; i++ ) {
                s.Insert( 1.3f, texts[i].DOFade( 1, .5f ) );
            }
            s.onComplete += () => func?.Invoke();
        }

        public void Rewind ( System.Action func = null ) {
            s.PlayBackwards();
            s.onRewind += () => func?.Invoke();
        }

        public void SetTexts ( params string[] texts ) {
            int dataLength = texts.Length;
            int uiLegth = this.texts.Count;
            int loops = dataLength > uiLegth ? dataLength : uiLegth;
            for ( int i = 0; i < loops; i++ ) {
                string data = i <= dataLength-1 ? texts[i] : null;
                TextMeshProUGUI ui = i <= uiLegth-1 ? this.texts[i] : null;
                if ( data != null && !ui ) {
                    TextMeshProUGUI t = Instantiate(textPrefab, textsContainer);
                    t.text = data;
                    t.autoSizeTextContainer = true;
                    this.texts.Add( t );
                }
                else if ( ui && data == null ) {
                    Destroy( ui.gameObject );
                }
                else {
                    ui.text = data;
                    ui.autoSizeTextContainer = true;
                }
            }
        }
    }
}
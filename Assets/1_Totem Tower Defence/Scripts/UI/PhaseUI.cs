namespace SweetRage {
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.UI;
    using TMPro;
    using DG.Tweening;

    public class PhaseUI : MonoBehaviour {
        [Header("Refs")]
        public TextMeshProUGUI textPrefab;
        public Transform textsContainer;
        public Image background;

        [Header("Events")]
        public UnityEvent OnPlay;

        private Sequence s;
        private List<TextMeshProUGUI> texts = new List<TextMeshProUGUI>();

        public void Setup () {
            background.transform.localScale = new Vector3( 1, 0, 1 );
            background.color = Color.clear;
        }

        public void Play ( float endWaitTime = 0, System.Action func = null ) {
            s = DOTween.Sequence();
            s.Append( background.DOFade( .9f, 1f ).SetEase( Ease.OutCubic ) );
            s.Join( background.transform.DOScaleY( 1, 1f ).SetEase( Ease.OutCubic ) );
            //s.Append( texts[0].DOFade( 1, .3f ) );
            for ( int i = 0; i < texts.Count; i++ ) {
                s.Append( texts[i].DOFade( 1, .3f ) );
            }
            s.AppendInterval( endWaitTime );
            s.onComplete += () => func?.Invoke();

            OnPlay.Invoke();
        }

        public void Rewind ( System.Action func = null ) {
            s = DOTween.Sequence();
            s.Append( texts[0].DOFade( 0, .3f ) );
            for ( int i = 1; i < texts.Count; i++ ) {
                s.Append( texts[i].DOFade( 0, .3f ) );
            }
            s.Append( background.DOFade( 0f, 1f ).SetEase( Ease.InCubic ) );
            s.Join( background.transform.DOScaleY( 0, 1f ).SetEase( Ease.InCubic ) );
            s.onComplete += () => func?.Invoke();
        }

        public void SetTexts ( params string[] texts ) {
            for ( int i = 0; i < textsContainer.childCount; i++ ) {
                Destroy( textsContainer.GetChild( i ).gameObject );
            }
            for ( int i = 0; i < texts.Length; i++ ) {
                TextMeshProUGUI t = Instantiate(textPrefab, textsContainer);
                t.text = texts[i];
                t.autoSizeTextContainer = true;
                this.texts.Add( t );
            }
        }

        public void SetTexts ( string texts ) {
            string[] words = texts.Split(' ');
            for ( int i = 0; i < textsContainer.childCount; i++ ) {
                Destroy( textsContainer.GetChild( i ).gameObject );
            }
            for ( int i = 0; i < words.Length; i++ ) {
                TextMeshProUGUI t = Instantiate(textPrefab, textsContainer);
                t.text = words[i];
                t.autoSizeTextContainer = true;
                this.texts.Add( t );
            }
        }
    }
}
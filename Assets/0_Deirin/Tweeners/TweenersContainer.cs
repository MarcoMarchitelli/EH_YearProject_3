namespace Deirin.Tweeners {
    using UnityEngine;
    using System.Collections.Generic;
    using UnityEngine.Events;

    public class TweenersContainer : MonoBehaviour {
        public bool fetchOnAwake = true;
        public List<BaseTweener> tweeners = new List<BaseTweener>();

        [Header("Events")]
        public UnityEvent OnPlay;
        public UnityEvent OnAllPlayEnd;
        public UnityEvent OnAllRewindEnd;

        private int playEndCount, rewindEndCount;

        private void Awake () {
            if ( fetchOnAwake )
                FetchTweeners();

            foreach ( var tweener in tweeners ) {
                tweener.OnPlayEnd.AddListener( TweenerPlayEndHandler );
                tweener.OnRewindEnd.AddListener( TweenerRewindEndHandler );
            }
        }

        #region API
        public void FetchTweeners () {
            tweeners.Clear();
            foreach ( var item in GetComponentsInChildren<BaseTweener>() ) {
                if ( item.ignoresContainer )
                    continue;
                tweeners.Add( item );
            }
        }

        public void Play () {
            foreach ( var tweener in tweeners )
                tweener.Play();
            OnPlay.Invoke();
        }

        public void Rewind () {
            foreach ( var tweener in tweeners )
                tweener.Rewind();
        }

        public void Stop () {
            for ( int i = 0; i < tweeners.Count; i++ ) {
                tweeners[i].Kill();
            }
        }
        #endregion

        private void TweenerPlayEndHandler () {
            playEndCount++;
            if ( playEndCount == tweeners.Count ) {
                OnAllPlayEnd.Invoke();
            }
        }

        private void TweenerRewindEndHandler () {
            rewindEndCount++;
            if ( rewindEndCount == tweeners.Count ) {
                OnAllRewindEnd.Invoke();
            }
        }
    }
}
namespace Deirin.Tweeners {
    using UnityEngine;
    using System.Collections.Generic;

    public class TweenersContainer : MonoBehaviour {
        public bool fetchOnAwake = true;
        public List<BaseTweener> tweeners = new List<BaseTweener>();

        private void Awake () {
            if ( fetchOnAwake )
                FetchTweeners();
        }

        public void FetchTweeners () {
            tweeners.Clear();
            foreach ( var item in GetComponentsInChildren<BaseTweener>() ) {
                if ( item.ignoresContainer )
                    continue;
                tweeners.Add( item );
            }
        }

        public void Play () {
            for ( int i = 0; i < tweeners.Count; i++ ) {
                tweeners[i].Play();
            }
        }

        public void Rewind () {
            for ( int i = 0; i < tweeners.Count; i++ ) {
                tweeners[i].Rewind();
            }
        }

        public void Stop () {
            for ( int i = 0; i < tweeners.Count; i++ ) {
                tweeners[i].Stop();
            }
        }
    }
}
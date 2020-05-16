namespace Deirin.Tweeners {
    using UnityEngine;
    using UnityEngine.Events;
    using DG.Tweening;

    public abstract class BaseTweener : MonoBehaviour {
        [Header("Tweener Params")]
        public bool ignoresContainer;
        [Min(0)] public float duration;
        public bool ignoresTimescale;
        [Min(0)] public float delay;
        public bool relative;
        public Ease ease;
        [Min(-1)] public int loops;
        public LoopType loopType;
        public bool smoothRewind = false;
        public bool autoKill = false;
        [Header("Events")]
        public UnityEvent OnPlay;
        public UnityEvent OnRewind;
        public UnityEvent OnPlayEnd;
        public UnityEvent OnRewindEnd;
        public UnityEvent OnKill;

        protected Tween tween;

        private void Awake () {
            TweenSetup();
        }

        protected abstract void AssignTween ();

        private void TweenSetup () {
            AssignTween();

            if ( tween == null )
                return;

            tween.SetUpdate( ignoresTimescale );
            tween.SetDelay( delay );
            tween.SetEase( ease );
            tween.SetLoops( loops, loopType );
            tween.SetAutoKill( autoKill );
            tween.SetRelative( relative );

            tween.onComplete += OnPlayEnd.Invoke;
            tween.onRewind += OnRewindEnd.Invoke;
        }

        public void Play () {
            OnPlay.Invoke();
            tween.PlayForward();
        }

        public void Rewind () {
            OnRewind.Invoke();
            //if ( smoothRewind )
            //    tween.SmoothRewind();
            //else
            tween.PlayBackwards();
        }

        public void Kill () {
            OnKill.Invoke();
            tween.Kill();
        }
    }
}
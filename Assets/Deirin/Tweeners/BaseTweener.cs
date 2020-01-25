namespace Deirin.Tweeners {
    using UnityEngine;
    using UnityEngine.Events;
    using DG.Tweening;

    public abstract class BaseTweener : MonoBehaviour {
        [Header("Tweener Params")]
        public bool ignoresContainer;
        [Min(0)] public float duration;
        public Ease ease;
        [Min(-1)] public int loops;
        public UnityEvent OnPlay;
        public UnityEvent OnRewind;
        public UnityEvent OnPlayEnd;
        public UnityEvent OnRewindEnd;
        public UnityEvent OnStop;

        public abstract void Play ();

        public abstract void Rewind ();

        public abstract void Stop ();
    }
}
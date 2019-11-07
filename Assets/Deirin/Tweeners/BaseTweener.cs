namespace Deirin.Tweeners {
    using UnityEngine;
    using UnityEngine.Events;
    using DG.Tweening;

    public abstract class BaseTweener : MonoBehaviour {
        [Header("Tweener Params")]
        [Min(0)] public float duration;
        public Ease ease;
        [Min(-1)] public int loops;
        public UnityEvent OnTweenerStart;
        public UnityEvent OnTweenerRewind;
        public UnityEvent OnTweenerEnd;

        public abstract void PlayTween ();

        public abstract void BackwardsTween ();

        public abstract void StopTween ();
    }
}
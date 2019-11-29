namespace Deirin.EB {
    using System.Collections;
    using UnityEngine;
    using UnityEngine.Events;

    public class Timer : BaseBehaviour {
        [Header("Params")]
        public float duration;
        public bool unscaledTime = false;

        [Header("Events")]
        public UnityEvent OnTimerStart;
        public UnityEvent OnTimerPause;
        public UnityEvent OnTimerEnd;

        bool count;
        float timer;

        public void Play () {
            if ( unscaledTime )
                StartCoroutine( CountUnscaled() );
            else
                StartCoroutine( Count() );
        }

        public void Pause () {
            count = false;
            OnTimerPause.Invoke();
        }

        public void Stop () {
            if ( unscaledTime )
                StopCoroutine( CountUnscaled() );
            else
                StopCoroutine( Count() );
        }

        IEnumerator Count () {
            timer = 0;
            count = true;

            OnTimerStart.Invoke();

            while ( count == true && timer < duration ) {
                timer += Time.deltaTime;
                yield return null;
            }

            OnTimerEnd.Invoke();
        }

        IEnumerator CountUnscaled () {
            float startTime = Time.time;
            timer = startTime;
            count = true;

            OnTimerStart.Invoke();

            while ( count == true && (timer - startTime) < duration ) {
                timer = Time.time;
                yield return null;
            }

            OnTimerEnd.Invoke();
        }
    }
}
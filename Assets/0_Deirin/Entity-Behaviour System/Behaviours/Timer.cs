namespace Deirin.EB {
    using Deirin.Utilities;
    using System.Collections;
    using UnityEngine;
    using UnityEngine.Events;

    public class Timer : BaseBehaviour, IStoppable {
        [Header("Params")]
        public float duration;
        public bool unscaledTime = false;

        [Header("Events")]
        public UnityEvent_Float OnTimerStart;
        public UnityEvent OnTimerPause;
        public UnityEvent_Float OnTimerEnd;

        bool count;
        float timer;

        public bool Stopped { get; private set; } = true;


        public void Play () {
            Stopped = false;

            if ( unscaledTime )
                StartCoroutine( CountUnscaled() );
            else
                StartCoroutine( Count() );
        }

        public void Pause () {
            count = false;
            OnTimerPause.Invoke();
        }

        public void Stop ( bool callEvent = false ) {
            Stopped = true;

            if ( unscaledTime )
                StopCoroutine( CountUnscaled() );
            else
                StopCoroutine( Count() );

            if ( callEvent )
                OnTimerEnd.Invoke( duration );
        }

        IEnumerator Count () {
            timer = 0;
            count = true;

            OnTimerStart.Invoke( duration );

            while ( count == true && timer < duration ) {
                timer += Time.deltaTime;
                yield return null;
            }

            OnTimerEnd.Invoke( duration );
        }

        IEnumerator CountUnscaled () {
            float startTime = Time.time;
            timer = startTime;
            count = true;

            OnTimerStart.Invoke( duration );

            while ( count == true && ( timer - startTime ) < duration ) {
                timer = Time.time;
                yield return null;
            }

            OnTimerEnd.Invoke( duration );
        }
    }
}
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
        [SerializeField] private UnityEvent onStop;

        private bool count;
        private float timer;
        private Coroutine currentRoutine;

        #region IStoppable
        public bool Stopped { get; private set; } = true;
        public UnityEvent OnStop { get => onStop; set => onStop = value; }
        public void Stop ( bool callEvent = false ) {
            if ( Stopped )
                return;

            Stopped = true;

            if ( currentRoutine != null )
                StopCoroutine( currentRoutine );

            if ( callEvent )
                OnStop.Invoke();
        }
        #endregion

        public void Play () {
            Stopped = false;

            currentRoutine = unscaledTime ? StartCoroutine( "CountUnscaled" ) : StartCoroutine( "Count" );
        }

        public void Pause () {
            count = false;
            OnTimerPause.Invoke();
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
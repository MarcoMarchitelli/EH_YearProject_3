namespace SweetRage {
    using UnityEngine;
    using DG.Tweening;
    using System.Collections;

    public class GameTimer : MonoBehaviour {
        [SerializeField] private float timeMultiplier;
        [SerializeField] private float tweenDuration;

        public static GameTimer instance;
        private bool paused;
        private float previousTimeScale, timer;

        public bool Paused => paused;

        private void Awake () {
            if ( !instance )
                instance = this;
        }

        #region API
        public void Pause () {
            previousTimeScale = Time.timeScale;
            StopAllCoroutines();
            StartCoroutine( TimeScaleAnim( 0 ) );
            paused = true;
        }

        public void Resume () {
            if ( paused ) {
                StopAllCoroutines();
                StartCoroutine( TimeScaleAnim( previousTimeScale ) );
                paused = false;
            }
        }

        public void SetTimeMultiplier ( float value ) {
            previousTimeScale = value;
            if ( paused == false ) {
                StopAllCoroutines();
                StartCoroutine( TimeScaleAnim( value ) );
            }
        }
        #endregion

        private IEnumerator TimeScaleAnim ( float value ) {
            timer = 0;
            previousTimeScale = Time.timeScale;
            while ( timer <= tweenDuration ) {
                timer += Time.fixedUnscaledDeltaTime;

                Time.timeScale = Mathf.Lerp( previousTimeScale, value, Mathf.Clamp01( timer / tweenDuration ) );
                yield return null;
            }
        }
    }
}
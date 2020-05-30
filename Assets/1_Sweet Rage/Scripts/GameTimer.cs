namespace SweetRage {
    using UnityEngine;
    using DG.Tweening;

    public class GameTimer : MonoBehaviour {
        [SerializeField] private float timeMultiplier;
        [SerializeField] private float tweenDuration;

        public static GameTimer instance;
        private bool paused;
        private float previousTimeScale;

        private void Awake () {
            if ( !instance )
                instance = this;
        }

        #region API
        public void Pause () {
            previousTimeScale = Time.timeScale;
            DOTween.To( GetTimeScale, SetTimeScale, 0, tweenDuration ).Play();
            paused = true;
        }

        public void Resume () {
            if ( paused ) {
                DOTween.To( GetTimeScale, SetTimeScale, previousTimeScale, tweenDuration ).Play();
                paused = false;
            }
        }

        public void SetTimeMultiplier ( float value ) {
            previousTimeScale = value;
            if ( paused == false )
                DOTween.To( GetTimeScale, SetTimeScale, value, tweenDuration ).Play();
        }
        #endregion

        private void SetTimeScale ( float value ) {
            Time.timeScale = value;
        }

        private float GetTimeScale () => Time.timeScale;
    }
}
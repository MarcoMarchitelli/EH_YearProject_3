namespace TotemTD {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class GameTimer : MonoBehaviour {
        [SerializeField] private float timeMultiplier;

        public static GameTimer instance;
        public static float TimeMultiplier => instance.timeMultiplier;

        private float previousTimeMultiplier;
        private bool paused;

        private void Awake () {
            if ( !instance )
                instance = this;
        }

        public void Pause () {
            previousTimeMultiplier = timeMultiplier;
            timeMultiplier = 0;
            paused = true;
        }

        public void Resume () {
            if ( paused ) {
                timeMultiplier = previousTimeMultiplier;
                paused = false;
            }
        }

        public void SetTimeMultiplier ( float value ) {
            timeMultiplier = value;
        }
    }
}
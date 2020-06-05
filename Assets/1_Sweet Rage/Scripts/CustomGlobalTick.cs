namespace SweetRage {
    using UnityEngine;

    public class CustomGlobalTick : MonoBehaviour {
        public static System.Action OnTick;

        public float tickInterval = .4f;

        private float timer;
        private void Update () {
            timer += Time.deltaTime;
            timer = Mathf.Max( timer, tickInterval );
            if ( timer == tickInterval ) {
                timer = 0;
                OnTick?.Invoke();
            }
        }
    }
}
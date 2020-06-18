namespace SweetRage {
    using UnityEngine;

    public class MainMenuCameraMovement : MonoBehaviour {
        public float intesity = 10;
        [Range(0,1)] public float speed = 1;

        private Vector3 startPosition;

        private void Awake () {
            startPosition = transform.localPosition;
        }

        private void Update () {
            float amount = Time.time * speed;
            Vector3 movement = new Vector3( Mathf.Cos(amount) * intesity, Mathf.Sin(amount) * intesity, 0 );
            transform.localPosition = startPosition + movement;
        }
    }
}
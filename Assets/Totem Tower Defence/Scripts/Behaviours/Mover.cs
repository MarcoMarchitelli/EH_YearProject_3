namespace TotemTD {
    using UnityEngine;

    public class Mover : MonoBehaviour {
        [Header("Params")]
        public float speed;
        public Vector3 orientation;

        private void Update () {
            transform.position += orientation * speed * Time.deltaTime;
        }
    }
}
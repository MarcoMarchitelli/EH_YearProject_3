namespace TotemTD {
    using UnityEngine;

    public class Mover : MonoBehaviour {
        [Header("Params")]
        public float speed;
        public Vector3 orientation;
        public Space space;

        private void Update () {
            transform.Translate( orientation * speed * Time.deltaTime, space );
        }
    }
}
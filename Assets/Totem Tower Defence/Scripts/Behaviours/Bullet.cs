namespace TotemTD {
    using UnityEngine;

    public class Bullet : MonoBehaviour {
        [Header("Params")]
        public float speed;
        public int damage;

        private void Update () {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }
}
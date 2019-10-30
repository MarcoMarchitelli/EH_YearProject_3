namespace TotemTD {
    using UnityEngine;

    public class LookAt : MonoBehaviour {
        public Transform target;

        private void Update () {
            transform.LookAt( target, Vector3.up );
        }

        public void SetTarget ( Transform target ) {
            this.target = target;
        }
    }
}
namespace TotemTD {
    using UnityEngine;

    public class Billboard : MonoBehaviour {
        [Header("Refs")]
        public Camera cam;

        [Header("Params")]
        public bool searchCameraOnAwake = true;

        private void Awake () {
            if ( searchCameraOnAwake )
                cam = Camera.main;
        }

        private void Update () {
            transform.LookAt( cam.transform );
        }
    }
}
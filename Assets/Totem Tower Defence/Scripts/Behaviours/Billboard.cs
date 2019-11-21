namespace TotemTD {
    using UnityEngine;

    public class Billboard : BaseBehaviour {
        [Header("Refs")]
        public Camera cam;

        [Header("Params")]
        public bool searchCameraOnAwake = true;

        public override void OnAwake () {
            if ( searchCameraOnAwake )
                cam = Camera.main;
        }

        public override void OnUpdate () {
            transform.LookAt( cam.transform );
        }
    }
}
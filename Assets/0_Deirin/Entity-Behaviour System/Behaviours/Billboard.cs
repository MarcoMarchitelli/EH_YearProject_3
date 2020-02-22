namespace Deirin.EB {
    using UnityEngine;

    public class Billboard : BaseBehaviour {
        [Header("Refs")]
        public Camera cam;

        [Header("Params")]
        public bool searchMainCameraOnAwake = true;

        public override void OnAwake () {
            if ( searchMainCameraOnAwake )
                cam = Camera.main;
        }

        public override void OnUpdate () {
            transform.LookAt( -cam.transform.position );
        }
    }
}
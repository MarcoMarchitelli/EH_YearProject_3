namespace Deirin.EB {
    using UnityEngine;

    public class Billboard : BaseBehaviour {
        [Header("Refs")]
        public Camera cam;

        [Header("Params")]
        public bool searchMainCameraOnSetup = true;

        protected override void CustomSetup () {
            if ( searchMainCameraOnSetup )
                cam = Camera.main;
        }

        public override void OnUpdate () {
            transform.LookAt( -cam.transform.position );
        }
    }
}
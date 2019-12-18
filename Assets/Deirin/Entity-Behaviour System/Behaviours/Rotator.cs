namespace Deirin.EB {
    using UnityEngine;

    public class Rotator : BaseBehaviour {
        [Header("Params")]
        public float speed;
        public Vector3 eulers;
        public Space space;

        private bool active;

        public override void OnUpdate () {
            if ( active == false )
                return;
            transform.Rotate( eulers * speed * Time.deltaTime, space );
        }

        public void Active ( bool value ) {
            active = value;
        }
    }
}
namespace Deirin.EB {
    using UnityEngine;

    public class Rotator : BaseBehaviour {
        [Header("Params")]
        public float speed;
        public Vector3 eulers;
        public Space space;

        public override void OnUpdate () {
            transform.Rotate( eulers * speed * Time.deltaTime, space );
        }
    }
}
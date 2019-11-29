namespace Deirin.EB {
    using UnityEngine;

    public class Mover : BaseBehaviour {
        [Header("Params")]
        public float speed;
        public Vector3 orientation;
        public Space space;

        public override void OnUpdate () {
            transform.Translate( orientation * speed * Time.deltaTime, space );
        }
    }
}
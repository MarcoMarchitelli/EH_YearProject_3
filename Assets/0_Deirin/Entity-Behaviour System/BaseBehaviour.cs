namespace Deirin.EB {
    using UnityEngine;

    public abstract class BaseBehaviour : MonoBehaviour {
        public BaseEntity Entity { get; private set; }

        public void Setup ( BaseEntity e ) {
            Entity = e;
            CustomSetup();
        }

        protected virtual void CustomSetup () {

        }

        public virtual void OnUpdate () {

        }

        public virtual void OnStart () {

        }

        public virtual void OnAwake () {

        }

        public virtual void OnOnEnable () {

        }

        public virtual void OnLateUpdate () {

        }

        public virtual void OnFixedUpdate () {

        }
    } 
}
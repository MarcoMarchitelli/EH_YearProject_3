namespace Deirin.EB {
    using System.Collections.Generic;
    using UnityEngine;

    public abstract class BaseEntity : MonoBehaviour {
        public bool setupOnAwake = false;

        public BaseBehaviour[] Behaviours { get; private set; }
        public bool active { get; private set; }

        public void Setup () {
            Behaviours = GetComponentsInChildren<BaseBehaviour>();
            for ( int i = 0; i < Behaviours.Length; i++ ) {
                Behaviours[i].Setup( this );
            }
            active = true;
            CustomSetup();
        }

        protected virtual void CustomSetup () {

        }

        /// <summary>
        /// Returns the first behaviour found of the specified type (null if none is found).
        /// </summary>
        /// <typeparam name="T">Behaviour class type</typeparam>
        /// <returns></returns>
        public T GetBehaviour<T> () where T : BaseBehaviour {
            T obj = null;
            for ( int i = 0; i < Behaviours.Length; i++ ) {
                if ( Behaviours[i] is T ) {
                    obj = Behaviours[i] as T;
                    break;
                }
            }
            return obj;
        }

        public bool TryGetBehaviour<T> ( out T b ) where T : BaseBehaviour {
            b = null;
            for ( int i = 0; i < Behaviours.Length; i++ ) {
                if ( Behaviours[i] is T ) {
                    b = Behaviours[i] as T;
                    break;
                }
            }
            return b != null;
        }

        public bool HasBehaviour<T> () where T : BaseBehaviour {
            for ( int i = 0; i < Behaviours.Length; i++ ) {
                if ( Behaviours[i] is T ) {
                    return true;
                }
            }
            return false;
        }

        public List<T> GetBehaviours<T> () where T : BaseBehaviour {
            List<T> objs = new List<T>();
            for ( int i = 0; i < Behaviours.Length; i++ ) {
                if ( Behaviours[i] is T )
                    objs.Add( Behaviours[i] as T );
            }
            return objs;
        }

        private void Awake () {
            if ( setupOnAwake )
                Setup();
            if ( !active )
                return;
            for ( int i = 0; i < Behaviours.Length; i++ ) {
                Behaviours[i].OnAwake();
            }
        }

        private void Start () {
            if ( !active )
                return;
            for ( int i = 0; i < Behaviours.Length; i++ ) {
                Behaviours[i].OnStart();
            }
        }

        private void Update () {
            if ( !active )
                return;
            for ( int i = 0; i < Behaviours.Length; i++ ) {
                Behaviours[i].OnUpdate();
            }
        }

        private void LateUpdate () {
            if ( !active )
                return;
            for ( int i = 0; i < Behaviours.Length; i++ ) {
                Behaviours[i].OnLateUpdate();
            }
        }

        private void FixedUpdate () {
            if ( !active )
                return;
            for ( int i = 0; i < Behaviours.Length; i++ ) {
                Behaviours[i].OnFixedUpdate();
            }
        }
    }
}
namespace Deirin.Utilities {
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu( menuName = "Deirin/Utilities/Global Game Events/Float" )]
    public class GameEvent_Float : ScriptableObject {
        [SerializeField] private float value;
        public System.Action<float> OnInvoke;

        private List<GameEventListener_Float> listeners = new List<GameEventListener_Float>();

        public void Subscribe ( GameEventListener_Float listener ) {
            listeners.Add( listener );
        }

        public void Unsubscribe ( GameEventListener_Float listener ) {
            listeners.Remove( listener );
        }

        public void Invoke () {
            for ( int i = 0; i < listeners.Count; i++ ) {
                listeners[i].OnInvoke( value );
            }
        }

        public void Invoke ( float value ) {
            for ( int i = 0; i < listeners.Count; i++ ) {
                listeners[i].OnInvoke( value );
            }
            OnInvoke?.Invoke( value );
        }
    }
}
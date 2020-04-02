namespace Deirin.Utilities {
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu( menuName = "Deirin/Utilities/Global Game Events/Void" )]
    public class GameEvent : ScriptableObject {
        private List<GameEventListener> listeners = new List<GameEventListener>();
        public System.Action OnInvoke;

        public void Subscribe( GameEventListener listener ) {
            listeners.Add( listener );
        }

        public void Unsubscribe ( GameEventListener listener ) {
            listeners.Remove( listener );
        }

        public void Invoke () {
            for ( int i = 0; i < listeners.Count; i++ ) {
                listeners[i].OnInvoke();
            }
            OnInvoke?.Invoke();
        }
    }
}
namespace SweetRage {
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu( menuName = "Sweet Rage/Custom Game Events/Level Object Event" )]
    public class LevelObjectGameEvent : ScriptableObject {
        public LevelObject ld;
        private List<LevelObjectGameEventListener> listeners = new List<LevelObjectGameEventListener>();

        public System.Action<LevelObject> OnInvoke;

        public void Subscribe ( LevelObjectGameEventListener listener ) {
            listeners.Add( listener );
        }

        public void Unsubscribe ( LevelObjectGameEventListener listener ) {
            listeners.Remove( listener );
        }

        public void Invoke () => Invoke( ld );

        public void Invoke ( LevelObject ld ) {
            for ( int i = 0; i < listeners.Count; i++ ) {
                listeners[i].OnInvoke( ld );
            }

            OnInvoke?.Invoke( ld );
        }

        [ContextMenu("Clear All")]
        public void ClearAll () {
            listeners.Clear();
        }
    }
}
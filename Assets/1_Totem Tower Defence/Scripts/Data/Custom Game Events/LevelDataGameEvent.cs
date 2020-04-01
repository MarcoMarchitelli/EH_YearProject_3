namespace SweetRage {
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu( menuName = "Sweet Rage/Custom Game Events/Level Data Event" )]
    public class LevelDataGameEvent : ScriptableObject {
        public LevelData ld;
        private List<LevelDataGameEventListener> listeners = new List<LevelDataGameEventListener>();
        private List<LevelDataGameEventListener_SM> listeners_SM = new List<LevelDataGameEventListener_SM>();

        public void Subscribe ( LevelDataGameEventListener listener ) {
            listeners.Add( listener );
        }

        public void Unsubscribe ( LevelDataGameEventListener listener ) {
            listeners.Remove( listener );
        }

        public void Subscribe ( LevelDataGameEventListener_SM listener ) {
            listeners_SM.Add( listener );
        }

        public void Unsubscribe ( LevelDataGameEventListener_SM listener ) {
            listeners_SM.Remove( listener );
        }

        public void Invoke () => Invoke( ld );

        public void Invoke ( LevelData ld ) {
            for ( int i = 0; i < listeners.Count; i++ ) {
                listeners[i].OnInvoke( ld );
            }

            for ( int i = 0; i < listeners_SM.Count; i++ ) {
                listeners_SM[i].OnInvoke( ld );
            }
        }
    }
}
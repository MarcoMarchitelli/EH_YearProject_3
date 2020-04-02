namespace SweetRage {
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu( menuName = "Sweet Rage/Custom Game Events/Level Entity Event" )]
    public class LevelEntityGameEvent : ScriptableObject {
        public LevelEntity ld;
        private List<LevelEntityGameEventListener> listeners = new List<LevelEntityGameEventListener>();
        private List<LevelEntityGameEventListener_SM> listeners_SM = new List<LevelEntityGameEventListener_SM>();

        public System.Action<LevelEntity> OnInvoke;

        public void Subscribe ( LevelEntityGameEventListener listener ) {
            listeners.Add( listener );
        }

        public void Unsubscribe ( LevelEntityGameEventListener listener ) {
            listeners.Remove( listener );
        }

        public void Subscribe ( LevelEntityGameEventListener_SM listener ) {
            listeners_SM.Add( listener );
        }

        public void Unsubscribe ( LevelEntityGameEventListener_SM listener ) {
            listeners_SM.Remove( listener );
        }

        public void Invoke () => Invoke( ld );

        public void Invoke ( LevelEntity ld ) {
            for ( int i = 0; i < listeners.Count; i++ ) {
                listeners[i].OnInvoke( ld );
            }

            for ( int i = 0; i < listeners_SM.Count; i++ ) {
                listeners_SM[i].OnInvoke( ld );
            }

            OnInvoke?.Invoke( ld );
        }

        [ContextMenu("Clear All")]
        public void ClearAll () {
            listeners.Clear();
            listeners_SM.Clear();
        }
    }
}
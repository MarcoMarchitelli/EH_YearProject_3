namespace SweetRage {
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu( menuName = "Sweet Rage/Custom Game Events/Enemy Game Event" )]
    public class EnemyGameEvent : ScriptableObject {
        public Enemy enemy;
        private List<EnemyGameEventListener> listeners = new List<EnemyGameEventListener>();

        public void Subscribe ( EnemyGameEventListener listener ) {
            listeners.Add( listener );
        }

        public void Unsubscribe ( EnemyGameEventListener listener ) {
            listeners.Remove( listener );
        }

        public void Invoke () {
            for ( int i = 0; i < listeners.Count; i++ ) {
                listeners[i].OnInvoke( enemy );
            }
        }

        public void Invoke ( Enemy e ) {
            for ( int i = 0; i < listeners.Count; i++ ) {
                listeners[i].OnInvoke( e );
            }
        }
    }
}
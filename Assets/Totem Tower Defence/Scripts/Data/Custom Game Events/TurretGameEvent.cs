namespace TotemTD {
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu( menuName = "Custom Game Events/Turret Game Event" )]
    public class TurretGameEvent : ScriptableObject {
        public TurretModule turret;
        private List<TurretGameEventListener> listeners = new List<TurretGameEventListener>();

        public void Subscribe ( TurretGameEventListener listener ) {
            listeners.Add( listener );
        }

        public void Unsubscribe ( TurretGameEventListener listener ) {
            listeners.Remove( listener );
        }

        public void Invoke () {
            for ( int i = 0; i < listeners.Count; i++ ) {
                listeners[i].OnInvoke( turret );
            }
        }

        public void Invoke ( TurretModule t ) {
            for ( int i = 0; i < listeners.Count; i++ ) {
                listeners[i].OnInvoke( t );
            }
        }
    }
}
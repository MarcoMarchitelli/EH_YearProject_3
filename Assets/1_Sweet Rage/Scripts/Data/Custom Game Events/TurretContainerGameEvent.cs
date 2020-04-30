namespace SweetRage {
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu( menuName = "Sweet Rage/Custom Game Events/Turret Container Game Event" )]
    public class TurretContainerGameEvent : ScriptableObject {
        public TurretContainer turretContainer;
        private List<TurretContainerGameEventListener> listeners = new List<TurretContainerGameEventListener>();

        public void Subscribe ( TurretContainerGameEventListener listener ) {
            listeners.Add( listener );
        }

        public void Unsubscribe ( TurretContainerGameEventListener listener ) {
            listeners.Remove( listener );
        }

        public void Invoke () {
            for ( int i = 0; i < listeners.Count; i++ ) {
                listeners[i].OnInvoke( turretContainer );
            }
        }

        public void Invoke ( TurretContainer t ) {
            for ( int i = 0; i < listeners.Count; i++ ) {
                listeners[i].OnInvoke( t );
            }
        }
    }
}
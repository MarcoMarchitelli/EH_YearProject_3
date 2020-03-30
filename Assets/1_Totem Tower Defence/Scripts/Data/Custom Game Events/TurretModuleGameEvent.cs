namespace SweetRage {
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu( menuName = "TotemTD/Custom Game Events/Turret Game Event" )]
    public class TurretModuleGameEvent : ScriptableObject {
        public TurretModule turret;
        private List<TurretModuleGameEventListener> listeners = new List<TurretModuleGameEventListener>();

        public void Subscribe ( TurretModuleGameEventListener listener ) {
            listeners.Add( listener );
        }

        public void Unsubscribe ( TurretModuleGameEventListener listener ) {
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
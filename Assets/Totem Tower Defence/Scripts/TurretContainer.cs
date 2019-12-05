namespace TotemTD {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class TurretContainer : MonoBehaviour {
        [Header("Parameters")]
        public int maxModules;
        public float moduleHeight;

        private List<TurretModule> modules = new List<TurretModule>();
        private bool hasShooter {
            get {
                for ( int i = 0; i < modules.Count; i++ ) {
                    if ( modules[i].HasBehaviour<Shooter>() )
                        return true;
                }
                return false;
            }
        }

        public bool AddModule ( TurretModule module ) {
            //(if we don't have space for a module) OR (the current module is not a shooter AND we don't have one).
            if ( modules.Count >= maxModules || ( hasShooter == false && module.HasBehaviour<Shooter>() == false ) )
                return false;
            modules.Add( module );
            Place( module );
            return true;
        }

        public void RemoveModule () {

        }

        private void Place ( TurretModule module ) {
            module.transform.position = transform.position + Vector3.up * moduleHeight * ( modules.Count - 1 );
            module.transform.localRotation = Quaternion.identity;
        }
    }
}
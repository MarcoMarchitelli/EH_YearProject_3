namespace TotemTD {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class TurretContainer : MonoBehaviour {
        [Header("Parameters")]
        public int maxModules;

        private List<TurretModule> modules = new List<TurretModule>();

        public bool AddModule ( TurretModule module ) {
            if ( modules.Count >= maxModules )
                return false;
            modules.Add( module );
            return true;
        }

        public void RemoveModule () {

        }
    }
}
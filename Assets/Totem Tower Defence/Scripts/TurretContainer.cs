namespace TotemTD {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class TurretContainer : MonoBehaviour {
        [Header("Parameters")]
        public int maxModules;
        public float moduleHeight;

        private List<TurretModule> modules = new List<TurretModule>();

        public bool AddModule ( TurretModule module ) {
            if ( modules.Count >= maxModules )
                return false;
            modules.Add( module );
            Place( module );
            return true;
        }

        public void RemoveModule () {

        }

        public void PreviewPosition ( TurretModule module ) {
            module.transform.position = transform.position + Vector3.up * moduleHeight * ( modules.Count - 1 );
            module.transform.localRotation = Quaternion.identity;
        }

        private void Place ( TurretModule module ) {
            module.transform.position = transform.position + Vector3.up * moduleHeight * ( modules.Count - 1 );
            module.transform.localRotation = Quaternion.identity;
        }
    }
}
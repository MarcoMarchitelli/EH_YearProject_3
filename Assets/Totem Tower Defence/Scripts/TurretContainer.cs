namespace TotemTD {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Events;

    public class TurretContainer : MonoBehaviour {
        [Header("Parameters")]
        public int maxModules;
        public float moduleHeight;

        private List<TurretModule> shooterModules = new List<TurretModule>();
        private List<TurretModule> elementModules = new List<TurretModule>();
        private List<TurretModule> modifierModules = new List<TurretModule>();
        private TurretModule previewModule;

        private bool hasShooter {
            get {
                for ( int i = 0; i < shooterModules.Count; i++ ) {
                    if ( shooterModules[i].type == TurretModule.ModuleType.shooter )
                        return true;
                }
                return false;
            }
        }
        private int moduleCount => shooterModules.Count + elementModules.Count + modifierModules.Count;

        public bool CanPlace ( TurretModule module ) {
            if ( moduleCount >= maxModules || ( hasShooter == false && module.type != TurretModule.ModuleType.shooter ) )
                return false;
            else
                return true;
        }

        public void Preview ( TurretModule module ) {
            if ( CanPlace( module ) ) {
                previewModule = module;
                SortModules( true );
            }
        }

        public void AddModule ( TurretModule module ) {
            switch ( previewModule.type ) {
                case TurretModule.ModuleType.shooter:
                shooterModules.Add( module );
                break;
                case TurretModule.ModuleType.element:
                elementModules.Add( module );
                break;
                case TurretModule.ModuleType.modifier:
                modifierModules.Add( module );
                break;
            }
        }

        private void SortModules ( bool withPreview = false ) {
            if ( withPreview )
                AddModule( previewModule );

            Vector3 pos = transform.position;
            for ( int i = 0; i < shooterModules.Count; i++ ) {
                pos += Vector3.up * i * moduleHeight;
                shooterModules[i].transform.position = pos;
                shooterModules[i].transform.rotation = Quaternion.identity;
            }
            for ( int i = 0; i < elementModules.Count; i++ ) {
                pos += Vector3.up * i * moduleHeight;
                elementModules[i].transform.position = pos;
                elementModules[i].transform.rotation = Quaternion.identity;
            }
            for ( int i = 0; i < modifierModules.Count; i++ ) {
                pos += Vector3.up * i * moduleHeight;
                modifierModules[i].transform.position = pos;
                modifierModules[i].transform.rotation = Quaternion.identity;
            }
        }
    }
}
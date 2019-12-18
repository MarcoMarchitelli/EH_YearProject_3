namespace TotemTD {
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Events;
    using Deirin.Utilities;

    public class TurretContainer : MonoBehaviour {
        public enum State { disasbled, enabled }

        [Header("Parameters")]
        public int maxModules;
        public float moduleHeight;
        [ReadOnly] public State state;

        private List<TurretModule> shooterModules = new List<TurretModule>();
        private List<TurretModule> elementModules = new List<TurretModule>();
        private List<TurretModule> modifierModules = new List<TurretModule>();
        private TurretModule previewModule;
        private Vector3 currentTopPosition;

        private bool hasShooter => shooterModules.Count > 0;
        private int moduleCount => shooterModules.Count + elementModules.Count + modifierModules.Count;

        public void SetState ( int state ) {
            this.state = ( State ) state;
        }

        public bool CanPlace ( TurretModule module ) {
            if ( moduleCount >= maxModules || ( hasShooter == false && module.type != TurretModule.ModuleType.shooter ) )
                return false;
            else
                return true;
        }

        public void Preview ( TurretModule module ) {
            previewModule = module;
            AddModule( previewModule );
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
            SortModules();
        }

        public void RemoveModule ( TurretModule module ) {
            switch ( previewModule.type ) {
                case TurretModule.ModuleType.shooter:
                if ( shooterModules.Contains( module ) == true )
                    shooterModules.Remove( module );
                break;
                case TurretModule.ModuleType.element:
                if ( elementModules.Contains( module ) == true )
                    elementModules.Remove( module );
                break;
                case TurretModule.ModuleType.modifier:
                if ( modifierModules.Contains( module ) == true )
                    modifierModules.Remove( module );
                break;
            }
            SortModules();
        }

        private void SortModules () {
            currentTopPosition = transform.position;
            for ( int i = 0; i < shooterModules.Count; i++ ) {
                shooterModules[i].transform.position = currentTopPosition;
                shooterModules[i].transform.rotation = Quaternion.identity;
                currentTopPosition += Vector3.up * moduleHeight;
            }
            for ( int i = 0; i < elementModules.Count; i++ ) {
                elementModules[i].transform.position = currentTopPosition;
                elementModules[i].transform.rotation = Quaternion.identity;
                currentTopPosition += Vector3.up * moduleHeight;
            }
            for ( int i = 0; i < modifierModules.Count; i++ ) {
                modifierModules[i].transform.position = currentTopPosition;
                modifierModules[i].transform.rotation = Quaternion.identity;
                currentTopPosition += Vector3.up * moduleHeight;
            }
        }
    }
    [System.Serializable]
    public class UnityTurretContainerEvent : UnityEvent<TurretContainer> { }
}
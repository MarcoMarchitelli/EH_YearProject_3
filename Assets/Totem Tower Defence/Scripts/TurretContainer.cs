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

        [Header("Events")]
        public UnityTurretContainerEvent onMouseEnter;
        public UnityTurretContainerEvent onMouseExit;

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

        private void OnMouseEnter () {
            if ( state == State.enabled )
                onMouseEnter.Invoke( this );
        }

        private void OnMouseExit () {
            if ( state == State.enabled )
                onMouseExit.Invoke( this );
        }

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
        }

        private void SortModules () {
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
    [System.Serializable]
    public class UnityTurretContainerEvent : UnityEvent<TurretContainer> { }
}
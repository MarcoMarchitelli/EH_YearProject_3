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

        private List<TurretModule> modules = new List<TurretModule>();
        private List<TurretModule> shooterModules = new List<TurretModule>();
        private List<TurretModule> elementModules = new List<TurretModule>();
        private List<TurretModule> modifierModules = new List<TurretModule>();
        private TurretModule previewModule;

        private bool hasShooter => shooterModules.Count > 0;
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
            if ( moduleCount >= maxModules || ( hasShooter == false && ( module is ShooterModule ) == false ) )
                return false;
            else
                return true;
        }

        public void Preview ( TurretModule module ) {
            previewModule = module;
            AddModule( previewModule );
        }

        public void AddModule ( TurretModule module ) {
            modules.Add( module );
            SortModules();
        }

        public void RemoveModule ( TurretModule module ) {
            if ( modules.Contains( module ) )
                modules.Remove( module );
        }

        private void SortModules () {
            Vector3 pos = transform.position;
            int i = 0;

            for ( ; i < shooterModules.Count; i++ ) {
                pos += Vector3.up * i * moduleHeight;
                shooterModules[i].transform.position = pos;
                shooterModules[i].transform.rotation = Quaternion.identity;
            }
            for ( ; i < elementModules.Count; i++ ) {
                pos += Vector3.up * i * moduleHeight;
                elementModules[i].transform.position = pos;
                elementModules[i].transform.rotation = Quaternion.identity;
            }
            for ( ; i < modifierModules.Count; i++ ) {
                pos += Vector3.up * i * moduleHeight;
                modifierModules[i].transform.position = pos;
                modifierModules[i].transform.rotation = Quaternion.identity;
            }
        }
    }
}
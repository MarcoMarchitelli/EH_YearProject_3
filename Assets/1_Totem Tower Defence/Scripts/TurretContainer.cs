namespace TotemTD {
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Events;
    using Deirin.Utilities;
    using DG.Tweening;

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
                HandleElementAttachment( module );
                break;
                case TurretModule.ModuleType.modifier:
                modifierModules.Add( module );
                break;
            }
            SortModules();
        }

        public void RemoveModule ( TurretModule module ) {
            switch ( module.type ) {
                case TurretModule.ModuleType.shooter:
                if ( shooterModules.Contains( module ) == true )
                    shooterModules.Remove( module );
                break;
                case TurretModule.ModuleType.element:
                if ( elementModules.Contains( module ) == true ) {
                    elementModules.Remove( module );
                    HandleElementDetachment( module );
                }
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

            if ( shooterModules.Count == 0 ) {
                Disassemble();
                return;
            }

            for ( int i = 0; i < shooterModules.Count; i++ ) {
                shooterModules[i].transform.DOMove( currentTopPosition, .2f ).SetEase( Ease.OutCubic );
                //shooterModules[i].transform.position = currentTopPosition;
                shooterModules[i].transform.rotation = Quaternion.identity;
                currentTopPosition += Vector3.up * moduleHeight;
            }
            for ( int i = 0; i < elementModules.Count; i++ ) {
                elementModules[i].transform.DOMove( currentTopPosition, .2f ).SetEase( Ease.OutCubic );
                //elementModules[i].transform.position = currentTopPosition;
                elementModules[i].transform.rotation = Quaternion.identity;
                currentTopPosition += Vector3.up * moduleHeight;
            }
            for ( int i = 0; i < modifierModules.Count; i++ ) {
                modifierModules[i].transform.DOMove( currentTopPosition, .2f ).SetEase( Ease.OutCubic );
                //modifierModules[i].transform.position = currentTopPosition;
                modifierModules[i].transform.rotation = Quaternion.identity;
                currentTopPosition += Vector3.up * moduleHeight;
            }
        }

        private void Disassemble () {
            for ( int i = 0; i < elementModules.Count; i++ ) {
                float duration = Random.Range(1.5f,3f);
                Vector3 pos = transform.position + Vector3.up * 2f + Random.insideUnitSphere;
                TurretModule module = elementModules[i];
                module.transform.DOJump( pos, Random.Range( 3, 5 ), Random.Range( 2, 5 ), 1.5f ).SetEase( Ease.OutCubic ).onComplete += () => module.OnDeselection.Invoke( module );
                module.transform.DOLocalRotate( new Vector3( Random.Range( 0, 360 ), Random.Range( 0, 360 ), Random.Range( 0, 360 ) ), duration ).SetEase( Ease.OutCubic );
            }
            elementModules.Clear();
            for ( int i = 0; i < modifierModules.Count; i++ ) {
                float duration = Random.Range(1.5f,3f);
                Vector3 pos = transform.position + Vector3.up * 2f + Random.insideUnitSphere;
                TurretModule module = modifierModules[i];
                module.transform.DOJump( pos, Random.Range( 3, 5 ), Random.Range( 2, 5 ), 1.5f ).SetEase( Ease.OutCubic ).onComplete += () => module.OnDeselection.Invoke( module );
                module.transform.DOLocalRotate( new Vector3( Random.Range( 0, 360 ), Random.Range( 0, 360 ), Random.Range( 0, 360 ) ), duration ).SetEase( Ease.OutCubic );
                modifierModules.Remove( modifierModules[i] );
            }
            modifierModules.Clear();
        }

        private void HandleElementAttachment ( TurretModule elementModule ) {
            Element e;
            if ( elementModule.TryGetBehaviour( out e ) ) {
                foreach ( var item in shooterModules ) {
                    ElementStatusHandler esh;
                    if ( item.TryGetBehaviour( out esh ) ) {
                        esh.Apply( e );
                    }
                }
            }
        }

        private void HandleElementDetachment ( TurretModule elementModule ) {
            Element e;
            if ( elementModule.TryGetBehaviour( out e ) ) {
                foreach ( var item in shooterModules ) {
                    ElementStatusHandler esh;
                    if ( item.TryGetBehaviour( out esh ) && esh.element == e ) {
                        esh.Remove();
                    }
                }
            }
        }
    }
    [System.Serializable]
    public class UnityTurretContainerEvent : UnityEvent<TurretContainer> { }
}
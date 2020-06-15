namespace SweetRage {
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Events;
    using Deirin.Utilities;
    using DG.Tweening;

    public class TurretContainer : MonoBehaviour {
        public enum State { disasbled, enabled }

        [Header("References")]
        public Transform firstModulePlacementPosition;
        public GameObject arrow;
        public CapsuleCollider capsuleCollider;

        [Header("Parameters")]
        public int maxModules;
        public float moduleHeight;
        public Vector3 arrowOffset;
        public float modulesAnimationDuration = .5f;
        [ReadOnly] public State state;

        private List<TurretModule> shooterModules = new List<TurretModule>();
        private List<TurretModule> elementModules = new List<TurretModule>();
        private List<TurretModule> modifierModules = new List<TurretModule>();
        private TurretModule previewModule;
        private Vector3 currentTopPosition;

        private bool hasShooter => shooterModules.Count > 0;
        private int moduleCount => shooterModules.Count + elementModules.Count + modifierModules.Count;

        private void Awake () => currentTopPosition = transform.position;

        #region API
        public void SetState ( int state ) {
            this.state = ( State ) state;
        }

        public bool CanPlace ( TurretModule module ) {
            if ( moduleCount >= maxModules || ( hasShooter == false && module.turretType.moduleType != TurretType.ModuleType.shooter ) )
                return false;
            else
                return true;
        }

        public void Preview ( TurretModule module ) {
            previewModule = module;
            AddModule( previewModule );
        }

        public void AddModule ( TurretModule module ) {
            switch ( module.turretType.moduleType ) {
                case TurretType.ModuleType.shooter:
                shooterModules.Add( module );

                ElementsContainer shooterElements;
                if ( module.TryGetBehaviour( out shooterElements ) )
                    foreach ( TurretModule elementModule in elementModules ) {
                        ElementSource element;
                        if ( elementModule.TryGetBehaviour( out element ) )
                            shooterElements.Add( element );
                    }

                ModifiersContainer shooterModifiers;
                if ( module.TryGetBehaviour( out shooterModifiers ) )
                    foreach ( TurretModule modifierModule in modifierModules ) {
                        ModifierSource modifier;
                        if ( modifierModule.TryGetBehaviour( out modifier ) ) {
                            shooterModifiers.Add( modifier );
                        }
                    }

                break;
                case TurretType.ModuleType.element:
                elementModules.Add( module );
                HandleElementAttachment( module );
                break;
                case TurretType.ModuleType.modifier:
                modifierModules.Add( module );
                HandleModifierAttachment( module );

                break;
            }

            capsuleCollider.height += moduleHeight;

            SortModules();
        }

        public void RemoveModule ( TurretModule module ) {
            switch ( module.turretType.moduleType ) {
                case TurretType.ModuleType.shooter:
                if ( shooterModules.Contains( module ) == true ) {
                    ElementsContainer sEle;
                    module.TryGetBehaviour( out sEle );
                    sEle?.RemoveAll();

                    ModifiersContainer sMod;
                    module.TryGetBehaviour( out sMod );
                    sMod?.RemoveAll();

                    shooterModules.Remove( module );
                }
                break;
                case TurretType.ModuleType.element:
                if ( elementModules.Contains( module ) == true ) {
                    elementModules.Remove( module );
                    HandleElementDetachment( module );
                }
                break;
                case TurretType.ModuleType.modifier:
                if ( modifierModules.Contains( module ) == true ) {
                    modifierModules.Remove( module );
                    HandleModiferDetachment( module );
                }
                break;
            }
            module.graphics.DOKill();
            module.graphics.position = module.transform.position;

            capsuleCollider.height -= moduleHeight;

            SortModules();
        }
        #endregion

        #region Privates
        private void SortModules () {
            currentTopPosition = firstModulePlacementPosition.position;

            if ( shooterModules.Count == 0 ) {
                Disassemble();
                return;
            }

            void SetModuleToPosition ( TurretModule module ) {
                module.transform.rotation = Quaternion.identity;
                Vector3 prevGraphic = module.graphics.position;
                module.transform.position = currentTopPosition;
                module.graphics.position = prevGraphic;
                module.graphics.DOMove( currentTopPosition, modulesAnimationDuration ).SetEase( Ease.OutCubic ).SetUpdate( true );
                module.graphics.DOPlay();
                currentTopPosition = module.topModuleSpot.position;
            }

            int i;
            for ( i = 0; i < shooterModules.Count; i++ ) {
                SetModuleToPosition( shooterModules[i] );
            }
            for ( i = 0; i < elementModules.Count; i++ ) {
                SetModuleToPosition( elementModules[i] );
            }
            for ( i = 0; i < modifierModules.Count; i++ ) {
                SetModuleToPosition( modifierModules[i] );
            }
        }

        private void Disassemble () {
            int i = 0;
            for ( i = 0; i < elementModules.Count; i++ ) {
                TurretModule module = elementModules[i];
                HandleElementDetachment( elementModules[i] );
                module.OnDeselection.Invoke( module );
            }
            for ( i = 0; i < modifierModules.Count; i++ ) {
                TurretModule module = modifierModules[i];
                HandleModiferDetachment( modifierModules[i] );
                module.OnDeselection.Invoke( module );
            }
            elementModules.Clear();
            modifierModules.Clear();
        }

        private void ActivateArrow ( TurretModule module ) {
            if ( moduleCount < maxModules ) {
                if ( module.turretType.moduleType == TurretType.ModuleType.shooter || hasShooter ) {
                    arrow.transform.position = currentTopPosition + arrowOffset;
                    arrow.SetActive( true );
                }
            }
        }
        #endregion

        #region Event Handlers
        public void HandleModuleSelection ( TurretModule module ) => ActivateArrow( module );

        public void HandleModuleDeselection ( TurretModule module ) => arrow.SetActive( false );

        public void HandleModulePlacement ( TurretModule module ) => arrow.SetActive( false );

        public void HandleModuleDeplacement ( TurretModule module ) => ActivateArrow( module );

        private void HandleElementAttachment ( TurretModule elementModule ) {
            ElementSource e;
            if ( elementModule.TryGetBehaviour( out e ) ) {
                foreach ( var item in shooterModules ) {
                    ElementsContainer esh;
                    if ( item.TryGetBehaviour( out esh ) ) {
                        esh.Add( e );
                    }
                }
            }
        }

        private void HandleElementDetachment ( TurretModule elementModule ) {
            ElementSource e;
            if ( elementModule.TryGetBehaviour( out e ) ) {
                foreach ( var item in shooterModules ) {
                    ElementsContainer esh;
                    if ( item.TryGetBehaviour( out esh ) ) {
                        esh.Remove( e );
                    }
                }
            }
        }

        private void HandleModifierAttachment ( TurretModule elementModule ) {
            ModifierSource e;
            if ( elementModule.TryGetBehaviour( out e ) ) {
                foreach ( var item in shooterModules ) {
                    ModifiersContainer esh;
                    if ( item.TryGetBehaviour( out esh ) ) {
                        esh.Add( e );
                    }
                }
            }
        }

        private void HandleModiferDetachment ( TurretModule elementModule ) {
            ModifierSource e;
            if ( elementModule.TryGetBehaviour( out e ) ) {
                foreach ( var item in shooterModules ) {
                    ModifiersContainer esh;
                    if ( item.TryGetBehaviour( out esh ) ) {
                        esh.Remove( e );
                    }
                }
            }
        }
        #endregion
    }

    [System.Serializable]
    public class UnityTurretContainerEvent : UnityEvent<TurretContainer> { }
}
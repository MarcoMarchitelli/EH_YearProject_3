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
        public float modulesAnimationDuration = .5f;
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
                case TurretModule.ModuleType.element:
                elementModules.Add( module );
                HandleElementAttachment( module );
                break;
                case TurretModule.ModuleType.modifier:
                modifierModules.Add( module );
                HandleModifierAttachment( module );

                break;
            }
            SortModules();
        }

        public void RemoveModule ( TurretModule module ) {
            switch ( module.type ) {
                case TurretModule.ModuleType.shooter:
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
                case TurretModule.ModuleType.element:
                if ( elementModules.Contains( module ) == true ) {
                    elementModules.Remove( module );
                    HandleElementDetachment( module );
                }
                break;
                case TurretModule.ModuleType.modifier:
                if ( modifierModules.Contains( module ) == true ) {
                    modifierModules.Remove( module );
                    HandleModiferDetachment( module );
                }
                break;
            }
            module.graphics.DOKill();
            module.graphics.position = module.transform.position;
            SortModules();
        }

        private void SortModules () {
            currentTopPosition = transform.position;

            if ( shooterModules.Count == 0 ) {
                Disassemble();
                return;
            }

            void SetModuleToPosition ( TurretModule module ) {
                module.transform.rotation = Quaternion.identity;
                Vector3 prevGraphic = module.graphics.position;
                module.transform.position = currentTopPosition;
                module.graphics.position = prevGraphic;
                module.graphics.DOMove( currentTopPosition, modulesAnimationDuration ).SetEase( Ease.OutCubic );
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
            for ( int i = 0; i < elementModules.Count; i++ ) {
                float duration = Random.Range(1.5f,3f);
                Vector3 pos = transform.position + Vector3.up * 2f + Random.insideUnitSphere;
                TurretModule module = elementModules[i];
                HandleElementDetachment( elementModules[i] );
                module.transform.DOJump( pos, Random.Range( 3, 5 ), Random.Range( 2, 5 ), 1.5f ).SetEase( Ease.OutCubic ).onComplete += () => module.OnDeselection.Invoke( module );
                module.transform.DOLocalRotate( new Vector3( Random.Range( 0, 360 ), Random.Range( 0, 360 ), Random.Range( 0, 360 ) ), duration ).SetEase( Ease.OutCubic );
            }
            elementModules.Clear();
            for ( int i = 0; i < modifierModules.Count; i++ ) {
                float duration = Random.Range(1.5f,3f);
                Vector3 pos = transform.position + Vector3.up * 2f + Random.insideUnitSphere;
                TurretModule module = modifierModules[i];
                HandleModiferDetachment( modifierModules[i] );
                module.transform.DOJump( pos, Random.Range( 3, 5 ), Random.Range( 2, 5 ), 1.5f ).SetEase( Ease.OutCubic ).onComplete += () => module.OnDeselection.Invoke( module );
                module.transform.DOLocalRotate( new Vector3( Random.Range( 0, 360 ), Random.Range( 0, 360 ), Random.Range( 0, 360 ) ), duration ).SetEase( Ease.OutCubic );
                modifierModules.Remove( modifierModules[i] );
            }
            modifierModules.Clear();
        }

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


    }
    [System.Serializable]
    public class UnityTurretContainerEvent : UnityEvent<TurretContainer> { }
}
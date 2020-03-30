namespace SweetRage {
    using UnityEngine;
    using System.Collections.Generic;

    public class ModulesMenuUI : MonoBehaviour {
        [Header("Data")]
        public TurretType[] turretTypes;

        [Header("Refs")]
        public Transform shootersMenu;
        public Transform elementsMenu;
        public Transform modifiersMenu;
        public CanvasGroup canvasGroup;

        [Header("Prefabs")]
        public ModuleGroupUI moduleGroupUIPrefab;

        private List<ModuleGroupUI> moduleGroupUIs;

        public void Setup () {
            moduleGroupUIs = new List<ModuleGroupUI>();
            ModuleGroupUI mgUI;
            foreach ( var turretType in turretTypes ) {
                switch ( turretType.moduleType ) {
                    case TurretType.ModuleType.shooter:
                    mgUI = Instantiate( moduleGroupUIPrefab, shootersMenu );
                    mgUI.turretType = turretType;
                    moduleGroupUIs.Add( mgUI );
                    break;
                    case TurretType.ModuleType.element:
                    mgUI = Instantiate( moduleGroupUIPrefab, elementsMenu );
                    mgUI.turretType = turretType;
                    moduleGroupUIs.Add( mgUI );
                    break;
                    case TurretType.ModuleType.modifier:
                    mgUI = Instantiate( moduleGroupUIPrefab, modifiersMenu );
                    mgUI.turretType = turretType;
                    moduleGroupUIs.Add( mgUI );
                    break;
                }
            }
        }

        public void UpdateUI () {
            foreach ( var moduleGroupUI in moduleGroupUIs ) {
                moduleGroupUI.ClearModules();
            }
            for ( int i = 0; i < RuntimeLevelData.turretModules.Count; i++ ) {
                TurretModule tm = RuntimeLevelData.turretModules[i];
                foreach ( var moduleGroupUI in moduleGroupUIs ) {
                    if ( moduleGroupUI.turretType == tm.turretType ) {
                        moduleGroupUI.AddModule( tm );
                        moduleGroupUI.UpdateUI();
                    }
                }
            }
        }

        public void Activate ( bool value ) {
            canvasGroup.blocksRaycasts = value;
            canvasGroup.interactable = value;
        }

        public void AddTurretModule ( TurretModule module ) {
            RuntimeLevelData.turretModules.Add( module );
            UpdateUI();
        }

        public void RemoveTurretModule ( TurretModule module ) {
            RuntimeLevelData.turretModules.Remove( module );
            UpdateUI();
        }
    }
}
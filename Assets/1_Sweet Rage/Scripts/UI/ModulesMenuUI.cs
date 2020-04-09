namespace SweetRage {
    using UnityEngine;
    using UnityEngine.UI;
    using System.Collections.Generic;

    public class ModulesMenuUI : MonoBehaviour {
        [Header("Data")]
        public TurretType[] turretTypes;

        [Header("Refs")]
        public Transform shootersMenu;
        public Transform elementsMenu;
        public Transform modifiersMenu;
        public CanvasGroup canvasGroup;
        public RectTransform rectTransform;

        [Header("Prefabs")]
        public ModuleGroupUI moduleGroupUIPrefab;

        private List<ModuleGroupUI> moduleGroupUIs;

        #region API
        public void Setup () {
            DestroyModuleGroupsUIs();

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
            LayoutRebuilder.ForceRebuildLayoutImmediate( rectTransform );
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
            foreach ( var moduleGroupUI in moduleGroupUIs ) {
                moduleGroupUI.gameObject.SetActive( moduleGroupUI.ModuleCount != 0 );
            }
            LayoutRebuilder.ForceRebuildLayoutImmediate( rectTransform );
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
        #endregion

        private void DestroyModuleGroupsUIs () {
            int count = shootersMenu.childCount;
            int i;
            for ( i = 0; i < count; i++ ) {
                Destroy( shootersMenu.GetChild( i ).gameObject );
            }
            count = elementsMenu.childCount;
            for ( i = 0; i < count; i++ ) {
                Destroy( elementsMenu.GetChild( i ).gameObject );
            }
            count = modifiersMenu.childCount;
            for ( i = 0; i < count; i++ ) {
                Destroy( modifiersMenu.GetChild( i ).gameObject );
            }
        }
    }
}
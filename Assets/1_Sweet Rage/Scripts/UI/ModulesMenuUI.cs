namespace SweetRage {
    using UnityEngine;
    using UnityEngine.UI;
    using System.Collections.Generic;

    public class ModulesMenuUI : MonoBehaviour {
        [Header("Data")]
        public TurretType[] turretTypes;

        [Header("Refs")]
        public ModuleMenuUI shootersMenu;
        public ModuleMenuUI elementsMenu;
        public ModuleMenuUI modifiersMenu;
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
                    mgUI = Instantiate( moduleGroupUIPrefab, shootersMenu.transform );
                    mgUI.turretType = turretType;
                    moduleGroupUIs.Add( mgUI );
                    break;
                    case TurretType.ModuleType.element:
                    mgUI = Instantiate( moduleGroupUIPrefab, elementsMenu.transform );
                    mgUI.turretType = turretType;
                    moduleGroupUIs.Add( mgUI );
                    break;
                    case TurretType.ModuleType.modifier:
                    mgUI = Instantiate( moduleGroupUIPrefab, modifiersMenu.transform );
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

            //cycle groups
            foreach ( var moduleGroupUI in moduleGroupUIs ) {
                //setactive false
                moduleGroupUI.gameObject.SetActive( false );
                //cycle modules
                for ( int i = 0; i < RuntimeLevelData.turretModules.Count; i++ ) {
                    TurretModule tm = RuntimeLevelData.turretModules[i];
                    //if equal => setactive true
                    if ( moduleGroupUI.turretType == tm.turretType ) {
                        moduleGroupUI.gameObject.SetActive( true );
                        moduleGroupUI.AddModule( tm );
                        moduleGroupUI.UpdateUI();
                    }
                }
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
            int count = shootersMenu.transform.childCount;
            int i;
            for ( i = 0; i < count; i++ ) {
                Destroy( shootersMenu.transform.GetChild( i ).gameObject );
            }
            count = elementsMenu.transform.childCount;
            for ( i = 0; i < count; i++ ) {
                Destroy( elementsMenu.transform.GetChild( i ).gameObject );
            }
            count = modifiersMenu.transform.childCount;
            for ( i = 0; i < count; i++ ) {
                Destroy( modifiersMenu.transform.GetChild( i ).gameObject );
            }
        }
    }
}
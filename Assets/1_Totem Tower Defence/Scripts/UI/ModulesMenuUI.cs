namespace TotemTD {
    using UnityEngine;

    public class ModulesMenuUI : MonoBehaviour {
        [Header("Refs")]
        public Transform shootersMenu;
        public Transform elementsMenu;
        public Transform modifiersMenu;
        public CanvasGroup canvasGroup;

        [Header("Prefabs")]
        public TurretModuleUI turretModuleUIPrefab;

        public void UpdateUI () {
            int count = shootersMenu.childCount;
            for ( int i = 0; i < count; i++ ) {
                Destroy( shootersMenu.GetChild( i ).gameObject );
            }
            count = elementsMenu.childCount;
            for ( int i = 0; i < count; i++ ) {
                Destroy( elementsMenu.GetChild( i ).gameObject );
            }
            count = modifiersMenu.childCount;
            for ( int i = 0; i < count; i++ ) {
                Destroy( modifiersMenu.GetChild( i ).gameObject );
            }

            for ( int i = 0; i < RuntimeLevelData.turretModules.Count; i++ ) {
                TurretModule tm = RuntimeLevelData.turretModules[i];
                TurretModuleUI tmUI;
                switch ( tm.type ) {
                    case TurretModule.ModuleType.shooter:
                    tmUI = Instantiate( turretModuleUIPrefab, shootersMenu );
                    tmUI.SetTurretModule( tm );
                    tmUI.UpdateUI();
                    break;
                    case TurretModule.ModuleType.element:
                    tmUI = Instantiate( turretModuleUIPrefab, elementsMenu );
                    tmUI.SetTurretModule( tm );
                    tmUI.UpdateUI();
                    break;
                    case TurretModule.ModuleType.modifier:
                    tmUI = Instantiate( turretModuleUIPrefab, modifiersMenu );
                    tmUI.SetTurretModule( tm );
                    tmUI.UpdateUI();
                    break;
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
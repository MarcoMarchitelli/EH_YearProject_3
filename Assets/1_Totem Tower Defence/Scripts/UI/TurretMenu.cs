namespace TotemTD {
    using System.Collections.Generic;
    using UnityEngine;
    using Deirin.CustomButton;

    public class TurretMenu : MonoBehaviour {
        [Header("Refs")]
        public TurretModuleUI turretUIPrefab;
        public CustomButtonBase openCloseButton;
        public Transform moduleUIsContainer;

        List<TurretModuleUI> turretModuleUIs = new List<TurretModuleUI>();

        public void AddTurretModule ( TurretModule module ) {
            RuntimeLevelData.turretModules.Add( module );
            UpdateUI();
            Activate( true );
        }

        public void RemoveTurretModule ( TurretModule module ) {
            RuntimeLevelData.turretModules.Remove( module );
            UpdateUI();
            Activate( true );
        }

        public void UpdateUI () {
            for ( int i = 0; i < moduleUIsContainer.childCount; i++ ) {
                Destroy( moduleUIsContainer.GetChild( i ).gameObject );
            }

            turretModuleUIs.Clear();

            for ( int i = 0; i < RuntimeLevelData.turretModules.Count; i++ ) {
                TurretModuleUI ui = Instantiate(turretUIPrefab, moduleUIsContainer);
                ui.SetTurretModule( RuntimeLevelData.turretModules[i] );
                ui.UpdateUI();
                turretModuleUIs.Add( ui );
            }
        }

        /// <summary>
        /// Sets active status of all buttons.
        /// </summary>
        /// <param name="value"></param>
        public void Activate ( bool value ) {
            openCloseButton.active = value;
            foreach ( var item in turretModuleUIs ) {
                item.button.active = value;
            }
        }
    }
}
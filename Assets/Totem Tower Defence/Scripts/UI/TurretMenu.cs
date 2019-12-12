namespace TotemTD {
    using System.Collections.Generic;
    using UnityEngine;
    using Deirin.CustomButton;

    public class TurretMenu : MonoBehaviour {
        [Header("Refs")]
        public TurretModuleUI turretUIPrefab;
        public CustomToggle_Canvas toggle;
        public Transform moduleUIsContainer;

        TurretModuleData[] turretModulesData;
        List<TurretModuleUI> turretModuleUIs = new List<TurretModuleUI>();

        public void SetTurrets ( List<TurretModuleData> turrets ) {
            this.turretModulesData = turrets.ToArray();
            UpdateUI();
        }

        public void SetTurrets ( TurretModuleData[] turrets ) {
            this.turretModulesData = turrets;
            UpdateUI();
        }

        public void UpdateUI () {
            for ( int i = 0; i < moduleUIsContainer.childCount; i++ ) {
                Destroy( moduleUIsContainer.GetChild( i ).gameObject );
            }

            turretModuleUIs.Clear();

            for ( int i = 0; i < turretModulesData.Length; i++ ) {
                TurretModuleUI ui = Instantiate(turretUIPrefab, moduleUIsContainer);
                ui.SetTurretModule( turretModulesData[i] );
                ui.UpdateUI();
                turretModuleUIs.Add( ui );
            }
        }

        /// <summary>
        /// Sets active status of all buttons.
        /// </summary>
        /// <param name="value"></param>
        public void Activate ( bool value ) {
            toggle.active = value;
            foreach ( var item in turretModuleUIs ) {
                item.button.active = value;
            }
        }
    }
}
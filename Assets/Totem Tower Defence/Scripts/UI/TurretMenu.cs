namespace TotemTD {
    using System.Collections.Generic;
    using UnityEngine;
    using Deirin.CustomButton;

    public class TurretMenu : MonoBehaviour {
        [Header("Refs")]
        public TurretModuleUI turretUIPrefab;
        public CustomToggle_Canvas toggle;

        List<TurretModule> turretModules;
        List<TurretModuleUI> turretModuleUIs = new List<TurretModuleUI>();

        public void SetTurrets ( List<TurretModule> turrets ) {
            this.turretModules = turrets;
        }

        public void UpdateUI () {

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
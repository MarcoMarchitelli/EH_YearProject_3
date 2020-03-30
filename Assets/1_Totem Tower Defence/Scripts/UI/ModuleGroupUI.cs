namespace SweetRage {
    using System.Collections.Generic;
    using UnityEngine;
    using TMPro;

    public class ModuleGroupUI : MonoBehaviour {
        [Header("Data")]
        public TurretType turretType;

        [Header("Refs")]
        public TextMeshProUGUI countText;
        public TurretModuleUI turretModuleUI;

        private List<TurretModule> modules;

        #region API
        public int ModuleCount => modules.Count;

        public void UpdateUI () {
            int modulesCount = modules.Count;
            if ( modulesCount > 0 ) {
                countText.text = modulesCount.ToString();
                turretModuleUI.SetTurretModule( modules[modulesCount - 1] );
                turretModuleUI.UpdateUI();
            }
        }

        public void SetModules ( List<TurretModule> modules ) {
            this.modules = modules;
        }

        public void ClearModules () {
            if ( modules != null ) {
                modules.Clear();
                UpdateUI();
            }
        }

        public void AddModule ( TurretModule module ) {
            if ( modules == null )
                modules = new List<TurretModule>();
            modules.Add( module );
            UpdateUI();
        }

        public void RemoveModule ( TurretModule module ) {
            if ( modules.Contains( module ) ) {
                modules.Remove( module );
                UpdateUI();
            }
        }
        #endregion
    }
}
namespace TotemTD {
    using UnityEngine;
    using TMPro;

    public class TurretModuleBuildUI : MonoBehaviour {
        [Header("References")]
        public TextMeshProUGUI nameText;

        [Header("Events")]
        public UnityTurretModuleEvent OnClick;

        private TurretModule module;
        public TurretModule Module => module;

        public void SetData ( TurretModule module ) {
            this.module = module;
            UpdateUI();
        }

        public void UpdateUI () {
            nameText.text = module.name;
        }

        public void Click () {
            OnClick.Invoke( module );
        }
    }
}
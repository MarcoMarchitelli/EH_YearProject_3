namespace TotemTD {
    using UnityEngine;
    using UnityEngine.UI;
    using Deirin.CustomButton;
    using Deirin.Utilities;
    using Deirin.EB;

    public class TurretModuleUI : MonoBehaviour {
        [Header("Refs")]
        public CustomButton_Canvas button;
        public Image image;

        [Header("Events")]
        public UnityTurretModuleEvent OnTurretSelection;

        [ReadOnly] public TurretModule turretModule;

        private SpriteGetter spriteGetter;

        public void SetTurretModule ( TurretModule turretModule ) {
            this.turretModule = turretModule;
            spriteGetter = this.turretModule.GetComponentInChildren<SpriteGetter>();
        }

        public void UpdateUI () {
            image.sprite = spriteGetter.sprite;
        }

        public void SelectTurret () {
            turretModule.gameObject.SetActive( true );
            turretModule.Setup();
            OnTurretSelection.Invoke( turretModule );
        }
    }
}
namespace TotemTD {
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.Events;
    using Deirin.CustomButton;
    using Deirin.EB;

    public class TurretModuleUI : MonoBehaviour {
        [Header("Refs")]
        public TurretModule turretModule;
        public CustomButton_Canvas button;
        public Image image;

        [Header("Events")]
        public UnityEvent OnTurretSelection;

        private SpriteGetter spriteGetter;

        public void SetTurretModule ( TurretModule turretModule ) {
            this.turretModule = turretModule;
            spriteGetter = this.turretModule.GetComponentInChildren<SpriteGetter>();
        }

        public void UpdateUI () {
            image.sprite = spriteGetter.sprite;
        }

        public void SelectTurret () {
            Instantiate( turretModule, transform.position, Quaternion.identity );
            OnTurretSelection.Invoke();
        }
    }
}
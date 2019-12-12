namespace TotemTD {
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.Events;
    using Deirin.CustomButton;
    using Deirin.EB;

    public class TurretModuleUI : MonoBehaviour {
        [Header("Refs")]
        public ShooterModule shooterModulePrefab;
        public ElementModule elementModulePrefab;
        public ModifierModule modifierModulePrefab;
        public CustomButton_Canvas button;
        public Image image;

        [Header("Events")]
        public UnityEvent OnTurretSelection;

        private TurretModuleData turretModuleData;

        public void SetTurretModule ( TurretModuleData turretModuleData ) {
            this.turretModuleData = turretModuleData;
        }

        public void UpdateUI () {
            image.sprite = turretModuleData.sprite;
        }

        public void SelectTurret () {
            if ( turretModuleData is ShooterModuleData ) {
                ShooterModule t = Instantiate( shooterModulePrefab, transform.position, Quaternion.identity );
                t.data = turretModuleData as ShooterModuleData;
            }
            else if ( turretModuleData is ElementModuleData ) {
                ElementModule t = Instantiate( elementModulePrefab, transform.position, Quaternion.identity );
                t.data = turretModuleData as ElementModuleData;
            }
            else if ( turretModuleData is ModifierModuleData ) {
                ModifierModule t = Instantiate( modifierModulePrefab, transform.position, Quaternion.identity );
                t.data = turretModuleData as ModifierModuleData;
            }
            OnTurretSelection.Invoke();
        }
    }
}
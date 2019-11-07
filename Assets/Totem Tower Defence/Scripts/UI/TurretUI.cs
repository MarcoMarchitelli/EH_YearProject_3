namespace TotemTD {
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.Events;
    using Deirin.CustomButton;

    public class TurretUI : MonoBehaviour {
        [Header("Refs")]
        public Turret turretPrefab;
        public CustomButton_Canvas button;
        public Image image;

        [Header("Events")]
        public UnityEvent OnTurretSelection;

        private TurretBaseData turretData;
        public TurretBaseData TurretData {
            get => turretData;
            set {
                turretData = value;
                image.sprite = turretData.sprite;
            }
        }

        public void SelectTurret () {
            Turret t = Instantiate( turretPrefab, transform.position, Quaternion.identity );
            t.data = turretData;
            t.Setup();
            OnTurretSelection.Invoke();
        }
    }
}
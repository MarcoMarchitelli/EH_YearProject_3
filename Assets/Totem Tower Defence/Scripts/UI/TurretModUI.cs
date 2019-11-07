namespace TotemTD {
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.Events;
    using Deirin.CustomButton;

    public class TurretModUI : MonoBehaviour {
        [Header("Refs")]
        public TurretModDisplay turretModPrefab;
        public CustomButton_Canvas button;
        public Image image;

        [Header("Events")]
        public UnityEvent OnTurretModSelection;

        private TurretModData turretModData;
        public TurretModData TurretModData {
            get => turretModData;
            set {
                turretModData = value;
                image.sprite = turretModData.sprite;
            }
        }

        public void SelectTurretMod () {
            TurretModDisplay t = Instantiate( turretModPrefab, transform.position, Quaternion.identity );
            t.data = turretModData;
            t.Setup();
            OnTurretModSelection.Invoke();
        }
    }
}
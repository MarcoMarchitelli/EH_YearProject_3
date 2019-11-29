namespace TotemTD {
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.Events;
    using Deirin.CustomButton;

    public class TurretModuleUI : MonoBehaviour {
        [Header("Refs")]
        public TurretModule turretPrefab;
        public CustomButton_Canvas button;
        public Image image;

        [Header("Events")]
        public UnityEvent OnTurretSelection;

        public void SelectTurret () {
            TurretModule t = Instantiate( turretPrefab, transform.position, Quaternion.identity );
            OnTurretSelection.Invoke();
        }
    }
}
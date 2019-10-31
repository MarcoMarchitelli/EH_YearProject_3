namespace TotemTD {
    using UnityEngine;
    using UnityEngine.Events;
    using Deirin.CustomButton;

    public class TurretUI : MonoBehaviour {
        [Header("Refs")]
        public Turret turretPrefab;
        public CustomButton_Canvas button;

        [Header("Events")]
        public UnityEvent OnTurretSelection;

        [HideInInspector] public TurretData turretData;

        public void SelectTurret () {
            Turret t = Instantiate( turretPrefab, transform.position, Quaternion.identity );
            t.data = turretData;
            t.Setup();
            OnTurretSelection.Invoke();
        }
    }
}
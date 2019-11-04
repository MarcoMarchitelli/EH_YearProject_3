namespace TotemTD {
    using UnityEngine;
    using UnityEngine.Events;
    using Deirin.CustomButton;

    public class TurretModUI : MonoBehaviour {
        [Header("Refs")]
        public TurretModDisplay turretModPrefab;
        public CustomButton_Canvas button;

        [Header("Events")]
        public UnityEvent OnTurretModSelection;

        [HideInInspector] public TurretModData turretModData;

        public void SelectTurretMod () {
            TurretModDisplay t = Instantiate( turretModPrefab, transform.position, Quaternion.identity );
            t.data = turretModData;
            t.Setup();
            OnTurretModSelection.Invoke();
        }
    }
}
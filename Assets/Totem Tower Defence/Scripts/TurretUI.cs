namespace TotemTD {
    using UnityEngine;
    using Deirin.CustomButton;

    public class TurretUI : MonoBehaviour {
        [Header("Refs")]
        public CustomButton_Canvas button;

        [HideInInspector] public GameObject turret;

        public void SelectTurret () {
            Instantiate( turret, transform.position, Quaternion.identity );
        }
    }
}
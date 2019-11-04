namespace TotemTD {
    using UnityEngine;

    public class TurretModDisplay : MonoBehaviour {
        [Header("Data")]
        public TurretModData data;

        [Header("Refs")]
        public MeshRenderer meshRenderer;

        [Header("Params")]
        public bool setupOnAwake = true;

        private void Awake () {
            if ( setupOnAwake )
                Setup();
        }

        public void Setup () {
            meshRenderer.material.color = data.color;
        }
    }
}
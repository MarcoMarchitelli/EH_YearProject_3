namespace SweetRage {
    using UnityEngine;
    using TMPro;

    public class WaveBuildStatsUI : MonoBehaviour {
        [Header( "Data" )]
        public WaveData waveData;

        [Header("References")]
        public TMP_InputField placementTimeInputField;
        public TMP_InputField spawnIntervalInputField;

        public void UpdateUI () {
            placementTimeInputField.text = waveData.placeTime.ToString();
            spawnIntervalInputField.text = waveData.spawnInterval.ToString();
        }

        public void SetPlacementTime ( string textValue ) {
            float.TryParse( textValue, out waveData.placeTime );
        }

        public void SetSpawnInterval ( string textValue ) {
            float.TryParse( textValue, out waveData.spawnInterval );
        }
    }
}
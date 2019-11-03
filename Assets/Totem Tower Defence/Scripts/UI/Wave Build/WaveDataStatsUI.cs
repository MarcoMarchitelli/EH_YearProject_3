namespace TotemTD {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class WaveDataStatsUI : MonoBehaviour {
        [Header("Data")]
        public WaveData data;

        public void SetPlaceTime ( string input ) {
            data.placeTime = float.Parse( input );
        }

        public void SetSpawnInterval (string input ) {
            data.spawnInterval = float.Parse( input );
        }
    }
}
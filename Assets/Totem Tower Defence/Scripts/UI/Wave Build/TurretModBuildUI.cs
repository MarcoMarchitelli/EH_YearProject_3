namespace TotemTD {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using TMPro;

    public class TurretModBuildUI : WaveBuildUI {
        public TurretModData customData;
        public TextMeshProUGUI nameText;

        protected override void CustomSetData () {
            customData = data as TurretModData;
            Refresh();
        }

        public override void Refresh () {
            nameText.text = customData.name;
        }
    }
}
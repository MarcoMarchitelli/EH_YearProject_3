namespace TotemTD {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using TMPro;

    public class TurretBaseBuildUI : WaveBuildUI {
        public TurretBaseData customData;
        public TextMeshProUGUI nameText;

        protected override void CustomSetData () {
            customData = data as TurretBaseData;
            Refresh();
        }

        public override void Refresh () {
            nameText.text = customData.name;
        }
    }
}
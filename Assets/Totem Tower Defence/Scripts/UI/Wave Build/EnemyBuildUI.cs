namespace TotemTD {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using TMPro;

    public class EnemyBuildUI : WaveBuildUI {
        public EnemyData customData;
        public TextMeshProUGUI nameText;

        protected override void CustomSetData () {
            customData = data as EnemyData;
            Refresh();
        }

        public override void Refresh () {
            nameText.text = customData.name;
        }
    }
}
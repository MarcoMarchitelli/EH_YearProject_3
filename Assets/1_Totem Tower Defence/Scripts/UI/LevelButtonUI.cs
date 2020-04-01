namespace SweetRage {
    using UnityEngine;
    using Deirin.Utilities;
    using TMPro;

    public class LevelButtonUI : MonoBehaviour {
        [ReadOnly] public LevelData level;
        [Header("Refs")]
        public TextMeshProUGUI text;

        public void UpdateUI () {
            text.text = level?.name;
        }
    }
}
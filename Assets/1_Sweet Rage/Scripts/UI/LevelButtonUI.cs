namespace SweetRage {
    using UnityEngine;
    using Deirin.Utilities;
    using TMPro;

    public class LevelButtonUI : MonoBehaviour {
        [ReadOnly] public LevelEntity level;
        [Header("Refs")]
        public TextMeshProUGUI text;
        [Header("Events")]
        public UnityEvent_LevelEntity OnClick;

        public void UpdateUI () {
            text.text = level?.levelName;
        }

        public void Click () {
            OnClick.Invoke( level );
        }
    }
}
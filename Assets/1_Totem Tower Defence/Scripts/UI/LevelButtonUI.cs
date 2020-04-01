namespace SweetRage {
    using UnityEngine;
    using Deirin.Utilities;
    using TMPro;

    public class LevelButtonUI : MonoBehaviour {
        [ReadOnly] public LevelData level;
        [Header("Refs")]
        public TextMeshProUGUI text;
        [Header("Events")]
        public UnityEvent_LevelData OnClick;

        public void UpdateUI () {
            text.text = level?.name;
        }

        public void Click () {
            OnClick.Invoke( level );
        }
    }
}
namespace TotemTD {
    using UnityEngine;
    using TMPro;

    public class EnemyBuildUI : MonoBehaviour {
        [Header("References")]
        public TextMeshProUGUI nameText;

        [Header("Events")]
        public UnityEnemyEvent OnClick;

        private Enemy enemy;
        public Enemy Enemy => enemy;

        public void SetData ( Enemy enemy ) {
            this.enemy = enemy;
            UpdateUI();
        }

        public void UpdateUI () {
            nameText.text = enemy.name;
        }

        public void Click () {
            OnClick.Invoke( enemy );
        }
    }
}
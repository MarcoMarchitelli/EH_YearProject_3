namespace SweetRage {
    using UnityEngine;

    public class MainMenuUI : MonoBehaviour {
        [Header("Prefabs")]
        public LevelButtonUI levelButtonPrefab;

        [Header("References")]
        public Transform levelButtonsContainer;

        private LevelEntity[] levels;

        public void SetLevelsData ( LevelEntity[] levels ) {
            this.levels = levels;
        }

        public void UpdateUI () {
            int count = levelButtonsContainer.childCount;

            for ( int i = 0; i < count; i++ ) {
                Destroy( levelButtonsContainer.GetChild( i ).gameObject );
            }

            for ( int i = 0; i < levels.Length; i++ ) {
                LevelButtonUI lbUI = Instantiate( levelButtonPrefab, levelButtonsContainer );
                lbUI.level = levels[i];
                lbUI.UpdateUI();
            }
        }
    }
}
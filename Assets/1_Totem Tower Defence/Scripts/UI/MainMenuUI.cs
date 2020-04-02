namespace SweetRage {
    using UnityEngine;

    public class MainMenuUI : MonoBehaviour {
        [Header("Prefabs")]
        public LevelButtonUI levelButtonPrefab;

        [Header("References")]
        public Transform levelButtonsContainer;

        private LevelData[] levelsData;

        public void SetLevelsData ( LevelData[] levelsData ) {
            this.levelsData = levelsData;
        }

        public void UpdateUI () {
            int count = levelButtonsContainer.childCount;

            for ( int i = 0; i < count; i++ ) {
                Destroy( levelButtonsContainer.GetChild( i ).gameObject );
            }

            for ( int i = 0; i < levelsData.Length; i++ ) {
                LevelButtonUI lbUI = Instantiate( levelButtonPrefab, levelButtonsContainer );
                lbUI.level = levelsData[i];
                lbUI.UpdateUI();
            }
        }
    }
}
namespace SweetRage {
    using System.Collections.Generic;
    using TMPro;
    using UnityEngine;

    public class MainMenuUI : MonoBehaviour {
        [Header("Prefabs")]
        public LevelUI levelUIPrefab;

        [Header("References")]
        public Transform levelUIsContainer;
        public LevelUI selectedLevelUI;

        private List<LevelUI> levelUIs = new List<LevelUI>();
        private LevelEntity[] levels;

        public void SetLevelsData ( LevelEntity[] levels ) {
            this.levels = levels;
        }

        public void UpdateUI () {
            int count = levelUIsContainer.childCount;

            for ( int i = 0; i < count; i++ ) {
                Destroy( levelUIsContainer.GetChild( i ).gameObject );
            }

            for ( int i = 0; i < levels.Length; i++ ) {
                LevelUI lUI = Instantiate( levelUIPrefab, levelUIsContainer );
                lUI.level = levels[i];
                lUI.UpdateUI();
                lUI.nameText.text = ( i + 1 ).ToString();
                levelUIs.Add( lUI );
            }

            levelUIs[0]?.Click();
        }
    }
}
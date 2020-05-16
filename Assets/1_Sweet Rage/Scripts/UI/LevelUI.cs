namespace SweetRage {
    using UnityEngine;
    using Deirin.Utilities;
    using TMPro;
    using UnityEngine.UI;

    public class LevelUI : MonoBehaviour {
        [ReadOnly] public LevelEntity level;

        [Header("Refs")]
        public TextMeshProUGUI nameText;
        public Image star1;
        public Image star2;
        public Image star3;
        public Sprite starEmpty;
        public Sprite starFull;

        [Header("Events")]
        public UnityEvent_LevelEntity OnClick;
        public UnityEvent_LevelEntity OnSelection;
        public UnityEvent_LevelEntity OnDeselection;

        public void SetLevel ( LevelEntity level ) {
            this.level = level;
        }

        public void LevelSelectHandler ( LevelEntity selectedLevel ) {
            if ( level == selectedLevel )
                OnSelection.Invoke( level );
            else
                OnDeselection.Invoke( level );
        }

        public void UpdateUI () {
            if ( !level )
                return;

            if ( nameText )
                nameText.text = level?.levelName;

            UpdateScoreUI();
        }

        public void UpdateScoreUI () {
            float percent = 1;

            if ( star1 )
                star1.sprite = percent >= .3f ? starFull : starEmpty;
            if ( star2 )
                star2.sprite = percent >= .6f ? starFull : starEmpty;
            if ( star3 )
                star3.sprite = percent >= .9f ? starFull : starEmpty;
        }

        public void Click () {
            OnClick.Invoke( level );
        }
    }
}
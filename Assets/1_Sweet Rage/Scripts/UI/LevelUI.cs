namespace SweetRage {
    using UnityEngine;
    using Deirin.Utilities;
    using TMPro;
    using UnityEngine.UI;

    public class LevelUI : MonoBehaviour {
        [ReadOnly] public LevelEntity level;

        [Header("Refs")]
        public TextMeshProUGUI nameText;
        public Image mapImage;
        public Image star1;
        public Image star2;
        public Image star3;
        public Sprite starEmpty;
        public Sprite starFull;
        public Color emptyStarColor;

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

            if ( mapImage )
                mapImage.sprite = level?.mapSprite;

            UpdateScoreUI();
        }

        public void UpdateScoreUI () {
            if ( star1 ) {
                if ( level.maxScore >= .3f )
                    star1.sprite = starFull;
                else {
                    star1.sprite = starEmpty;
                    star1.color = emptyStarColor;
                }
            }
            if ( star2 ) {
                if ( level.maxScore >= .6f )
                    star2.sprite = starFull;
                else {
                    star2.sprite = starEmpty;
                    star2.color = emptyStarColor;
                }
            }
            if ( star3 ) {
                if ( level.maxScore >= .9f )
                    star3.sprite = starFull;
                else {
                    star3.sprite = starEmpty;
                    star3.color = emptyStarColor;
                }
            }
        }

        public void Click () {
            OnClick.Invoke( level );
        }
    }
}
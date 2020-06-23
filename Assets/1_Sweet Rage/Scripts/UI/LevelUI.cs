namespace SweetRage {
    using UnityEngine;
    using Deirin.Utilities;
    using TMPro;
    using UnityEngine.UI;

    public class LevelUI : MonoBehaviour {
        [ReadOnly] public LevelObject levelObject;

        [Header("Refs")]
        public TextMeshProUGUI nameText;
        public Image mapImage;
        public Image star1;
        public Image star2;
        public Image star3;
        public Image lockedImage;
        public Sprite starEmpty;
        public Sprite starFull;
        public Color emptyStarColor;

        [Header("Events")]
        public UnityEvent_LevelEntity OnClick;
        public UnityEvent_LevelObject OnClickObject;
        public UnityEvent_LevelEntity OnSelection;
        public UnityEvent_LevelEntity OnDeselection;

        public void SetLevel ( LevelObject level ) {
            this.levelObject = level;
        }

        public void LevelSelectHandler ( LevelObject selectedLevel ) {
            if ( levelObject == selectedLevel )
                OnSelection.Invoke( levelObject.entity );
            else
                OnDeselection.Invoke( levelObject.entity );
        }

        public void UpdateUI () {
            if ( levelObject == null )
                return;

            if ( nameText )
                nameText.text = levelObject.entity.levelName;

            if ( mapImage )
                mapImage.sprite = levelObject.entity.mapSprite;

            if ( lockedImage ) {
                star1.gameObject.SetActive( !levelObject.entity.state.locked );
                star2.gameObject.SetActive( !levelObject.entity.state.locked );
                star3.gameObject.SetActive( !levelObject.entity.state.locked );
                lockedImage.gameObject.SetActive( levelObject.entity.state.locked );
            }

            UpdateScoreUI();
        }

        public void UpdateScoreUI () {
            if ( star1 ) {
                if ( levelObject.entity.state.maxScore >= .3f )
                    star1.sprite = starFull;
                else {
                    star1.sprite = starEmpty;
                    star1.color = emptyStarColor;
                }
            }
            if ( star2 ) {
                if ( levelObject.entity.state.maxScore >= .6f )
                    star2.sprite = starFull;
                else {
                    star2.sprite = starEmpty;
                    star2.color = emptyStarColor;
                }
            }
            if ( star3 ) {
                if ( levelObject.entity.state.maxScore >= .9f )
                    star3.sprite = starFull;
                else {
                    star3.sprite = starEmpty;
                    star3.color = emptyStarColor;
                }
            }
        }

        public void Click () {
            OnClick.Invoke( levelObject.entity );
            OnClickObject.Invoke( levelObject );
        }
    }
}
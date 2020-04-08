namespace SweetRage {
    using UnityEngine;
    using UnityEngine.UI;

    public class PlaceTimeUI : MonoBehaviour {
        [Header("Refs")]
        public Image timerImage;

        private float percent;

        private void UpdateUI () {
            if ( timerImage )
                timerImage.fillAmount = Mathf.Clamp01( percent );
        }

        public void SetPercent ( float percent ) {
            this.percent = percent;
            UpdateUI();
        }
    }
}
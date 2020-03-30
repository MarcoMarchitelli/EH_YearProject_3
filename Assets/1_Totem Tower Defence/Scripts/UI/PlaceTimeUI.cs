namespace SweetRage {
    using UnityEngine;
    using UnityEngine.UI;
    using TMPro;

    public class PlaceTimeUI : MonoBehaviour {
        [Header("Refs")]
        public TextMeshProUGUI text;
        public Image timerImage;

        float timer, time;
        bool counting;

        private void Update () {
            if ( counting ) {
                timer += Time.deltaTime * GameTimer.TimeMultiplier;
                UpdateUI();
                if ( timer >= time ) {
                    timer = 0;
                    counting = false;
                }
            }
        }

        private void UpdateUI () {
            if ( text )
                text.text = ( time - timer ).ToString( "f0" );
            if ( timerImage )
                timerImage.fillAmount = Mathf.Clamp01( timer / time );
        }

        public void StartCounting () {
            timer = 0;
            counting = true;
        }

        public void SetTime ( float time ) {
            this.time = time;
        }
    }
}
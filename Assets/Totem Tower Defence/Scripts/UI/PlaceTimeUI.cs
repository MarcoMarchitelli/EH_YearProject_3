namespace TotemTD {
    using UnityEngine;
    using TMPro;

    public class PlaceTimeUI : MonoBehaviour {
        [Header("Refs")]
        public TextMeshProUGUI text;

        float timer, time;
        bool counting;

        private void Update () {
            if ( counting ) {
                timer += Time.deltaTime;
                text.text = ( time - timer ).ToString( "f0" );
                if ( timer >= time ) {
                    timer = 0;
                    counting = false;
                }
            }
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
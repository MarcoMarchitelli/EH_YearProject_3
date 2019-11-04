namespace TotemTD {
    using UnityEngine;
    using UnityEngine.UI;
    using DG.Tweening;

    public class EnemyLifeUI : MonoBehaviour {
        [Header("Refs")]
        public Enemy enemy;
        public Slider slider;
        public Image[] images;

        [Header("Params")]
        public float fadeDuration = .5f;
        public float visibleTime = 1.5f;

        private float timer;
        private bool count;

        private void Awake () {
            enemy.OnSetup += Setup;
        }

        public void Setup () {
            foreach ( var item in images ) {
                item.color = new Color( item.color.r, item.color.g, item.color.b, 0 );
            }
            enemy.OnLifeChange += SetLife;
            slider.maxValue = enemy.data.life;
            slider.value = slider.maxValue;
        }

        private void Update () {
            if ( count ) {
                timer += Time.deltaTime;
                if ( timer >= visibleTime )
                    FadeOut();
            }
        }

        public void SetLife ( float value ) {
            FadeIn();
            slider.value = value;
        }

        public void FadeIn () {
            foreach ( var item in images ) {
                item.DOKill();
                item.DOFade( 1, fadeDuration );
            }
            timer = 0;
            count = true;
        }

        public void FadeOut () {
            count = false;
            foreach ( var item in images ) {
                item.DOKill();
                item.DOFade( 0, fadeDuration );
            }
        }

        private void OnDestroy () {
            enemy.OnSetup -= Setup;
        }
    }
}
namespace SweetRage {
    using DG.Tweening;
    using UnityEngine;

    public class BlurUIController : MonoBehaviour {
        [Header("Refs")]
        public Material material;

        [Header("Paramters")]
        public string propertyName;
        public float targetValue;
        public float duration;
        public Ease ease;

        private int propertyID;
        private Tween tween;

        private void Awake () {
            propertyID = Shader.PropertyToID( propertyName );
            tween = material.DOFloat( targetValue, propertyID, duration ).SetEase( ease );
            tween.SetAutoKill( false );
        }

        public void Play () {
            tween.PlayForward();
        }

        public void Rewind () {
            tween.PlayBackwards();
        }

        public void Kill () {
            tween.Kill();
        }
    }
}
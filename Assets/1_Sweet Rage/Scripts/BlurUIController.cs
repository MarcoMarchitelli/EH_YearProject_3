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

        private void Awake () {
            propertyID = Shader.PropertyToID( propertyName );
        }

        public void Play () {
            material.DOFloat( targetValue, propertyID, duration )
            .SetEase( ease )
            .SetAutoKill( true )
            .PlayForward();
        }

        public void Play ( float duration ) {
            material.DOFloat( targetValue, propertyID, duration )
            .SetEase( ease )
            .SetAutoKill( true )
            .PlayForward();
        }

        public void SetTargetValue ( float value ) {
            targetValue = value;
        }
    }
}
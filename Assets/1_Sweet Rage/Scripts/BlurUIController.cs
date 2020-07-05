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
            material.DOFloat( targetValue,"_Size", duration )
            .SetEase( ease )
            .SetAutoKill( true );
        }

        public void Play ( float duration ) {
            material.DOFloat( targetValue, "_Size", duration )
            .SetEase( ease )
            .SetAutoKill( true );
        }

        public void SetTargetValue ( float value ) {
            targetValue = value;
        }
    }
}
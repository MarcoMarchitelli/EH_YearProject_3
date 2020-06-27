namespace SweetRage {
    using UnityEngine;

    public class TransitionElementsController : MonoBehaviour {
        public RectTransform[] elements;

        [Range(0,1)] public float horizontalOffsetPercent;
        [Range(0,1)] public float widthOffsetPercent;

        public void SetElements () {
            float width = Screen.width + Screen.width * horizontalOffsetPercent;
            int count = elements.Length;

            float sw = width / count;
            
            for ( int i = 0; i < count; i++ ) {
                var item = elements[i];
                item.sizeDelta = new Vector2( sw + widthOffsetPercent * sw, item.sizeDelta.y );
                item.anchoredPosition = new Vector2( sw * i, item.anchoredPosition.y );
            }
        }
    }
}
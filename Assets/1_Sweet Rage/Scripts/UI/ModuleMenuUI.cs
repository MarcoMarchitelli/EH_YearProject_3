namespace SweetRage {
    using System.Collections.Generic;
    using UnityEngine;

    public class ModuleMenuUI : MonoBehaviour {
        public RectTransform self;
        public float elementsDistance;
        public float elementWidth;
        public float horizontalSpaceing;
        public float speed;

        private List<RectTransform> activeChildren = new List<RectTransform>();
        private float startingHeight;

        private void Start () {
            startingHeight = self.sizeDelta.y;
        }

        private void Update () {
            UpdateActiveChildren();
            int count = activeChildren.Count;

            //adjust width
            float targetWidth = count * elementWidth + horizontalSpaceing * 2 + (count - 1) * elementsDistance;
            Vector2 targetSize = new Vector2( targetWidth, count > 0 ? startingHeight : startingHeight * .5f );
            self.sizeDelta = Vector2.MoveTowards( self.sizeDelta, targetSize, Time.unscaledDeltaTime * speed );

            //adjust elements pos
            int i = 1;
            while ( i <= count ) {
                var element = activeChildren[ i - 1 ];

                float xPos = horizontalSpaceing + (i - 1) * elementWidth + (i - 1) * elementsDistance + elementWidth * .5f;
                Vector2 targetPos = new Vector2( xPos, self.sizeDelta.y * .5f );
                element.anchoredPosition = Vector2.MoveTowards( element.anchoredPosition, targetPos, Time.unscaledDeltaTime * speed );
                i++;
            }
        }

        private void UpdateActiveChildren () {
            activeChildren.Clear();

            int count = transform.childCount;
            for ( int i = 0; i < count; i++ ) {
                var child = transform.GetChild(i);
                if ( child.gameObject.activeSelf )
                    activeChildren.Add( child as RectTransform );
            }
        }
    }
}
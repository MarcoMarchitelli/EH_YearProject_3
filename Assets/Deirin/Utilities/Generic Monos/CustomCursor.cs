namespace Deirin.Utilities {
    using UnityEngine;
    using UnityEngine.UI;

    public class CustomCursor : MonoBehaviour {
        [Header("References")]
        public Image image;

        private void Awake () {
            Cursor.visible = false;
        }

        private void Update () {
            transform.position = Input.mousePosition;
        }

        public void ChangeSprite ( Sprite sprite ) {
            image.sprite = sprite;
        }
    }
}
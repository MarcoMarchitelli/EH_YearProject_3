namespace TotemTD {
    using UnityEngine;
    using UnityEngine.Events;

    public class Placeable : MonoBehaviour {
        [Header("Params")]
        public LayerMask cellMask;

        [Header("Events")]
        public UnityEvent OnPlacement;

        bool placed;
        Camera cam;
        Cell currentCell;

        private void Awake () {
            cam = Camera.main;
        }

        private void Update () {
            SnapToGrid();
            if ( !placed && Input.GetMouseButtonUp( 0 ) )
                Place();
        }

        public void Place () {
            transform.position = currentCell.transform.position;
            placed = true;
            OnPlacement.Invoke();
        }

        public void SnapToGrid () {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if ( Physics.Raycast( ray, out hit, 50, cellMask ) ) {
                Cell c = hit.collider.GetComponent<Cell>();
                if ( c ) {
                    currentCell = c;
                    transform.position = c.transform.position;
                }
            }
        }
    }
}
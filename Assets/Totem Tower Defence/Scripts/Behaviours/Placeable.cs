﻿namespace TotemTD {
    using UnityEngine;
    using UnityEngine.Events;

    public class Placeable : MonoBehaviour {
        [Header("Params")]
        public LayerMask cellMask;
        public Color placeableColor;
        public Color unplaceableColor;

        [Header("Events")]
        public UnityEvent OnPlacement;
        public UnityColorEvent OnCurrentCellChange;

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
            if ( !currentCell.empty )
                return;
            transform.position = currentCell.transform.position + Vector3.up * .5f;
            placed = true;
            currentCell.empty = false;
            OnPlacement.Invoke();
        }

        public void SnapToGrid () {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if ( Physics.Raycast( ray, out hit, 300, cellMask ) ) {
                Cell c = hit.collider.GetComponent<Cell>();
                if ( c ) {
                    SetCurrentCell( c );
                }
            }
            else {
                if ( !currentCell )
                    transform.position = Input.mousePosition;
            }
        }

        void SetCurrentCell ( Cell c ) {
            currentCell = c;
            transform.position = currentCell.transform.position + Vector3.up *.5f;
            OnCurrentCellChange.Invoke( currentCell.empty ? placeableColor : unplaceableColor );
        }
    }

    [System.Serializable]
    public class UnityColorEvent : UnityEvent<Color> { }
}
namespace TotemTD {
    using UnityEngine;
    using UnityEngine.Events;
    using Deirin.Utilities;

    public class PlaceableMod : MonoBehaviour {
        [Header("Refs")]
        public TurretModDisplay turretModDisplay;

        [Header("Params")]
        public LayerMask cellMask;
        public Color placeableColor;
        public Color unplaceableColor;

        [Header("Events")]
        public GameEvent placementEvent;
        public TurretGameEvent deplacementEvent;
        public UnityTurretEvent OnPlacement;
        public UnityColorEvent OnCurrentCellChange;
        public UnityColorEvent OnCurrentTurretChange;

        bool placed;
        Camera cam;
        Cell currentCell;
        Turret currentTurret;

        private void Awake () {
            cam = Camera.main;
        }

        private void Update () {
            SnapToGrid();
            if ( !placed && Input.GetMouseButtonUp( 0 ) )
                Place();
            else if ( !placed && Input.GetMouseButtonUp( 1 ) )
                deplacementEvent.Invoke();
        }

        public void Place () {
            if ( !currentTurret || !currentTurret.freeSlots )
                return;
            currentTurret.AddModDisplay( turretModDisplay );
            placed = true;
            currentCell.empty = false;
            placementEvent.Invoke();
            OnPlacement.Invoke( currentTurret );
        }

        public void SnapToGrid () {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if ( Physics.Raycast( ray, out hit, 300, cellMask ) ) {
                Cell c = hit.collider.GetComponent<Cell>();
                if ( c ) {
                    SetCurrentCell( c );
                    currentTurret = null;
                    return;
                }
                Turret t = hit.collider.GetComponentInParent<Turret>();
                if ( t ) {
                    SetCurrentTurret( t );
                }
            }
            else {
                if ( !currentCell ) {
                    Vector3 mouseWorldPos = cam.ScreenToWorldPoint(Input.mousePosition);
                    transform.position = new Vector3( mouseWorldPos.x, 0, mouseWorldPos.y );
                }
            }
        }

        void SetCurrentCell ( Cell c ) {
            currentCell = c;
            transform.position = currentCell.transform.position + Vector3.up * .5f;
            OnCurrentCellChange.Invoke( unplaceableColor );
        }

        void SetCurrentTurret ( Turret c ) {
            currentTurret = c;
            transform.position = currentTurret.modDisplaysContainer.position;
            OnCurrentTurretChange.Invoke( currentTurret.freeSlots ? placeableColor : unplaceableColor );
        }
    }

    [System.Serializable]
    public class UnityTurretEvent : UnityEvent<Turret> {

    }
}
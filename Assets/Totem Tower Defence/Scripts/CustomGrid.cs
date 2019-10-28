namespace TotemTD {
    using UnityEngine;

    public class CustomGrid : MonoBehaviour {
        [Header("Refs")]
        public Cell cellPrefab;

        [Header("Params")]
        public Vector2Int size;
        public Vector3 cellSize;
        public LayerMask unplaceableMask;
        public bool gizmos;

        public static CustomGrid instance;

        private GameObject gridContainer;
        private Cell[,] cells;

        private void Awake () {
            if ( instance == null )
                instance = this;
        }

        public void GenerateGrid () {
            if ( gridContainer )
                DestroyImmediate( gridContainer );
            gridContainer = new GameObject( "Grid Container" );
            gridContainer.transform.SetParent( transform );
            cells = new Cell[size.x, size.y];

            for ( int x = 0; x < size.x; x++ ) {
                for ( int y = 0; y < size.y; y++ ) {
                    Vector3 cellPos = new Vector3(-size.x*cellSize.x/2+x*cellSize.x + cellSize.x/2,0,-size.y*cellSize.y/2+y*cellSize.y + cellSize.y/2);
                    Cell cell = Instantiate(cellPrefab, cellPos, Quaternion.identity);
                    cell.transform.localScale = cellSize;
                    cell.transform.SetParent( gridContainer.transform );
                    Collider[] hits = Physics.OverlapBox(cellPos, cellSize/2, cell.transform.rotation, unplaceableMask);
                    if ( hits.Length > 0 )
                        cell.unplaceable = true;
                    cells[x, y] = cell;
                }
            }
        }

        private void OnDrawGizmos () {
            if ( gizmos && gridContainer ) {
                for ( int x = 0; x < cells.GetLength( 0 ); x++ ) {
                    for ( int y = 0; y < cells.GetLength( 1 ); y++ ) {
                        Gizmos.color = cells[x, y].unplaceable ? Color.red : Color.green;
                        Gizmos.DrawWireCube( cells[x, y].transform.position, cellSize );
                    }
                }
            }
        }
    }
}
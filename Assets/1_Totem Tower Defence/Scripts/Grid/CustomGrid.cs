namespace TotemTD {
    using UnityEngine;

    public class CustomGrid : MonoBehaviour {
        [Header("Refs")]
        public CustomGridData gridData;
        public Cell cellPrefab;

        [Header("Params")]
        public Vector2Int size;
        public Vector3 cellSize;
        public LayerMask unplaceableMask;
        public bool gizmos;

        private GameObject gridContainer;

        public void GenerateGrid () {
            if ( gridContainer )
                DestroyImmediate( gridContainer );
            gridContainer = new GameObject( "Grid Container" );
            gridContainer.transform.SetParent( transform );
            gridData.cells = new Cell[size.x, size.y];

            for ( int x = 0; x < size.x; x++ ) {
                for ( int y = 0; y < size.y; y++ ) {
                    Vector3 cellPos = new Vector3(-size.x*cellSize.x/2+x*cellSize.x + cellSize.x/2,0,-size.y*cellSize.y/2+y*cellSize.y + cellSize.y/2);
                    Cell cell = Instantiate(cellPrefab, cellPos, Quaternion.identity);
                    cell.transform.localScale = cellSize;
                    cell.transform.SetParent( gridContainer.transform );
                    Collider[] hits = Physics.OverlapBox(cellPos, cellSize/2, cell.transform.rotation, unplaceableMask);
                    cell.empty = hits.Length > 0 ? false : true;
                    gridData.cells[x, y] = cell;
                }
            }
        }

        private void OnDrawGizmos () {
            if ( gizmos && gridContainer ) {
                for ( int x = 0; x < gridData.cells.GetLength( 0 ); x++ ) {
                    for ( int y = 0; y < gridData.cells.GetLength( 1 ); y++ ) {
                        Gizmos.color = gridData.cells[x, y].empty ? Color.green : Color.red;
                        Gizmos.DrawWireCube( gridData.cells[x, y].transform.position, cellSize );
                    }
                }
            }
        }
    }
}
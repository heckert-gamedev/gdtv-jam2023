using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace Jam
{

    public class BoardManager : MonoBehaviour
    {
        [SerializeField] private Vector2Int _dimensions;
        [SerializeField] private GameObject _cell;
        [SerializeField] private BoardCell[,] grid;
        [SerializeField] private GameObject _piece;
        [SerializeField] private Material _highlight;

        [SerializeField] Material playerMaterial;
        [SerializeField] Material enemyMaterial;

        private int[,] gridPieces;

        private List<GameObject> _pieces;


        private void Awake()
        {
            gridPieces = new int[_dimensions.x, _dimensions.y];
            CreateBoard();
        }


        private void CreateBoard()
        {
            grid = new BoardCell[_dimensions.x, _dimensions.y];
            var xl = _dimensions.x;
            var yl = _dimensions.y;

            Vector2Int cellPos = new Vector2Int();

            foreach (Transform gridCell in transform)
            {
                cellPos.x = (int)gridCell.position.x;
                cellPos.y = (int)gridCell.position.z;
                grid[cellPos.x, cellPos.y] = new BoardCell(null, gridCell.gameObject, _highlight, false);
            }

            AddPieces();
        }

        private void AddPieces()
        {
            int last = _dimensions.y - 1;

            for (int i = 0; i < _dimensions.x; i++)
            {
                grid[i, 0].piece = Instantiate(_piece, grid[i, 0].cellObject.transform.position, Quaternion.identity);
                grid[i, 0].piece.transform.parent = gameObject.transform;
                grid[i, 0].containsPlayerPiece = true;
                LODGroup lodGroup = grid[i, 0].piece.GetComponent<LODGroup>();
                LOD[] lods = lodGroup.GetLODs();
                lods[0].renderers[0].material = playerMaterial;
                lods[1].renderers[0].material = playerMaterial;
                lods[2].renderers[0].material = playerMaterial;
                /*Material[] playerMaterials = grid[i, 0].piece.GetComponent<MeshRenderer>().materials;
                playerMaterials[0] = playerMaterial;
                grid[i, 0].piece.GetComponent<MeshRenderer>().materials = playerMaterials;*/
                grid[i, last].piece = Instantiate(_piece, grid[i, last].cellObject.transform.position, Quaternion.identity);
                grid[i, last].piece.transform.parent = gameObject.transform;

                lodGroup = grid[i, last].piece.GetComponent<LODGroup>();
                lods = lodGroup.GetLODs();
                lods[0].renderers[0].material = enemyMaterial;
                lods[1].renderers[0].material = enemyMaterial;
                lods[2].renderers[0].material = enemyMaterial;
                grid[i, last].piece.transform.rotation = Quaternion.Euler(0, 180f, 0);
                /*Material[] enemyMaterials = grid[i, 0].piece.GetComponent<MeshRenderer>().materials;
                enemyMaterials[0] = enemyMaterial;
                grid[i, last].piece.GetComponent<MeshRenderer>().materials = enemyMaterials;*/
            }
        }

        private void HighlightPossibleMove()
        {

        }

        public void MovePiece(Vector2Int from, Vector2Int to)
        {
            grid[to.x, to.y].piece = grid[from.x, from.y].piece;
            grid[to.x, to.y].piece.transform.position = grid[to.x, to.y].cellObject.transform.position;
            grid[from.x, from.y].piece = null;
            grid[to.x, to.y].containsPlayerPiece = grid[from.x, from.y].containsPlayerPiece;
            grid[from.x, from.y].containsPlayerPiece = false;
        }

        public void RemovePiece(Vector2Int cell)
        {
            Destroy(grid[cell.x, cell.y].piece);
            grid[cell.x, cell.y].piece = null;
        }

        public bool CheckMove(Vector2Int start, Vector2Int end)
        {
            if(start.x == end.x && start.y == end.y) return false;
            if(!(Mathf.Abs(start.x - end.x) <= 1 && Mathf.Abs(start.y - end.y) <= 1)) return false;
            if(IsTileOccupied(end))
            {
                if(!IsMoveACapture(start, end)) return false;
            }
            return true;
        }

        public bool IsTileOccupied(Vector2Int coords)
        {
            return (grid[coords.x, coords.y].piece != null);
        }

        public bool IsTilePlayerPiece(Vector2Int coords)
        {
            return (grid[coords.x, coords.y].containsPlayerPiece);
        }

        public bool IsMoveACapture(Vector2Int start, Vector2Int end)
        {
            
            return (IsTileOccupied(start) && IsTileOccupied(end) && (IsTilePlayerPiece(start) != IsTilePlayerPiece(end)));
        }
    }
}

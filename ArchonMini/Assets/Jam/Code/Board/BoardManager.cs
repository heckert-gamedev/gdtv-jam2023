using System.Collections;
using System.Collections.Generic;
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

        private BoardCell from;
        private BoardCell to;

        private int[,] gridPieces;

        private List<GameObject> _pieces;


        private void OnEnable()
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
                grid[cellPos.x, cellPos.y] = new BoardCell(null, gridCell.gameObject, _highlight);
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
                grid[i, last].piece = Instantiate(_piece, grid[i, last].cellObject.transform.position, Quaternion.identity);
                grid[i, last].piece.transform.parent = gameObject.transform;
            }
        }

        private void HighlightPossibleMove()
        {

        }

        public void MovePiece(BoardCell from, BoardCell to)
        {

        }

        public void RemovePiece(BoardCell cell)
        {

        }

        public bool CheckMove(Vector2Int start, Vector2Int end)
        {
            if(Mathf.Abs(start.x - end.x) == 1 && Mathf.Abs(start.y - end.y) == 1)
            {
                return true;
            }
            else return false;
        }
    }
}

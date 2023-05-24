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

        //These variables will be populated by board interaction procedure.
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

Debug.Log("CreateBoard");
            foreach (Transform gridCell in transform)
            {
                cellPos.x = (int)gridCell.position.x;
                cellPos.y = (int)gridCell.position.z;
                Debug.Log($"pos {cellPos.x}, {cellPos.y}");
                grid[cellPos.x, cellPos.y] = new BoardCell(null, gridCell.gameObject, _highlight);
            }

            /*            
            for (int i = 0; i < yl; i++)
            {
                for (int y = 0; y < xl; y++)
                {
                    grid[i, y] = new BoardCell(null, Instantiate(_cell), _highlight);
                    grid[i, y].cellObject.transform.parent = gameObject.transform;
                    grid[i, y].cellObject.transform.position = new Vector3((transform.position.x + y) * _cell.transform.localScale.x, 0F, (transform.position.z + i) * _cell.transform.localScale.z);
                }
            }
            */

            Debug.Log($"{grid}");

            AddPieces();
        }

        private void AddPieces()
        {
            int last = _dimensions.y - 1;

            for (int i = 0; i < _dimensions.x; i++)
            {
                Debug.Log($"position {i}, 0 ");
                Debug.Log($"tile {grid[i,0].cellObject.name}");
                grid[i, 0].piece = Instantiate(_piece, grid[i, 0].cellObject.transform.position, Quaternion.identity);
                Debug.Log($"position {i}, {last} ");
                Debug.Log($" {grid[i,last].cellObject.name}");
                grid[i, last].piece = Instantiate(_piece, grid[i, last].cellObject.transform.position, Quaternion.identity);

                //grid[0, i].piece.transform.parent = gameObject.transform;
                //grid[0, i].piece.transform.position = new Vector3((transform.position.x + i) * _cell.transform.localScale.x, 0.2F, transform.position.z * _cell.transform.localScale.z);
            }

            /*
            for (int i = 0; i < _dimensions.y; i++)
            {
                var p = Instantiate(_piece);
                //p.transform.parent = gameObject.transform;
                //p.transform.position = new Vector3((transform.position.x + i) * _cell.transform.localScale.x, 0.2F, (transform.position.z + last) * _cell.transform.localScale.z);
            }
            */
        }

        private void HighlightPossibleMove()
        {

        }

        public void MovePiece(BoardCell from, BoardCell to)
        {

        }
    }
}

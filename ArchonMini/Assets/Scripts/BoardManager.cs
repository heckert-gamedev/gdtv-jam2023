using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct BoardCell
{
    [SerializeField] public GameObject piece;
    [SerializeField] public GameObject cellObject;

    public Material highlightMat;
    public Material origin;

    private void HighlightCell()
    {
        origin = cellObject.GetComponent<MeshRenderer>().material;
        cellObject.GetComponent<MeshRenderer>().material = highlightMat;
    }

    public void EndHighlight()
    {
        cellObject.GetComponent<MeshRenderer>().material = origin;
    }
}

public class BoardManager : MonoBehaviour
{
    [SerializeField] private Vector2 _dimensions;
    [SerializeField] private GameObject _cell;
    [SerializeField] private BoardCell[,] grid;
    [SerializeField] private GameObject _piece;

    private int[,] gridPieces;

    private List<GameObject> _pieces;

    private void OnEnable()
    {
        gridPieces = new int[(int)_dimensions.x, (int)_dimensions.y];
        CreateBoard();

    }

    private void CreateBoard()
    {
        grid = new BoardCell[(int)_dimensions.x, (int)_dimensions.y];
        var xl = (int)_dimensions.x;
        var yl = (int)_dimensions.y;

        for (int i = 0; i < yl; i++)
        {
            for (int y = 0; y < xl; y++)
            {
                grid[i, y].cellObject = Instantiate(_cell);
                grid[i, y].cellObject.transform.parent = gameObject.transform;
                grid[i, y].cellObject.transform.position = new Vector3((transform.position.x + y) * _cell.transform.localScale.x, 0F, (transform.position.z + i) * _cell.transform.localScale.z);
            }
        }

        AddPieces();
    }

    private void AddPieces()
    {
        int last = (int)_dimensions.y - 1;

        for (int i = 0; i < _dimensions.x; i++)
        {
            grid[0, i].piece = Instantiate(_piece);
            grid[0, i].piece.transform.parent = gameObject.transform;
            grid[0, i].piece.transform.position = new Vector3((transform.position.x + i) * _cell.transform.localScale.x, 0.2F, transform.position.z * _cell.transform.localScale.z);
        }

        for (int i = 0; i < _dimensions.y; i++)
        {
            var p = Instantiate(_piece);
            p.transform.parent = gameObject.transform;
            p.transform.position = new Vector3((transform.position.x + i) * _cell.transform.localScale.x, 0.2F, (transform.position.z + last) * _cell.transform.localScale.z);
        }
    }

    private void HighlightPossibleMove(int x, int y)
    {

    }
}

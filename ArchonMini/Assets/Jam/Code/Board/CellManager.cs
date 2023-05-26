using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jam
{
    [System.Serializable]
    public struct BoardCell
    {
        [SerializeField] public GameObject piece;
        [SerializeField] public GameObject cellObject;

        public BoardCell(GameObject p, GameObject cell, Material mat)
        {
            piece = p;
            cellObject = cell;
            highlightMat = mat;
            origin = null;

            cell.GetComponent<CellManager>().SetCell(this);
        }

        [Header("Assign materials")]
        public Material highlightMat;
        public Material origin;

        public void SetPiece(GameObject p)
        {
            piece = p;
        }

        public void HighlightCell()
        {
            origin = cellObject.GetComponent<MeshRenderer>().material;
            cellObject.GetComponent<MeshRenderer>().material = highlightMat;
        }

        public void EndHighlight()
        {
            cellObject.GetComponent<MeshRenderer>().material = origin;
        }
    }

    public class CellManager : MonoBehaviour
    {
        [SerializeField] private BoardCell _cellInfo;
        public delegate void CellEvents(BoardCell cell);
        public static CellEvents onMouseOverCell;

        private void OnMouseOver()
        {
            Debug.Log(string.Format("On {0}", gameObject.name));
            onMouseOverCell?.Invoke(_cellInfo);
        }

        public void SetCell(BoardCell info)
        {
            _cellInfo = info;
        }
    }
}

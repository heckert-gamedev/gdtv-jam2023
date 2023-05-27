using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace Jam
{
    public class BoardInteraction : MonoBehaviour
    {
        private BoardCell from;
        private BoardCell to;
        [SerializeField] private BoardCell current;

        private void SetCurrent(BoardCell v) => current = v;

        private void OnEnable()
        {
            CellManager.onMouseOverCell += SetCurrent;
        }

        private void OnDisable()
        {
            CellManager.onMouseOverCell -= SetCurrent;
        }

        public void Interaction(CallbackContext ctx)
        {
            if (!ctx.performed) return;

            if (current.cellObject != null)
            {
                from = to;
                from.HighlightCell();
            }
        }
    }
}

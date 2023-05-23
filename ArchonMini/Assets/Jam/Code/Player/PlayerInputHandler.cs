using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jam
{
    public class PlayerInputHandler : MonoBehaviour
    {
        [SerializeField] bool isOrthogonalMovement = true;

        PlayerInputMap inputActions;

        public Vector3 moveVector;

        public bool isPressingTriggerBoard;
        public bool isPressingTriggerBattle;


        private void Awake()
        {
            inputActions = new PlayerInputMap();
        }


        private void OnEnable()
        {
            inputActions.Enable();

            if (isOrthogonalMovement)
            {
                inputActions.OrthogonalMovement.UpDown.performed += _ => OnUpDownAction();
                inputActions.OrthogonalMovement.UpDown.canceled += _ => OnStopMovementAction();
                inputActions.OrthogonalMovement.LeftRight.performed += _ => OnLeftRightAction();
                inputActions.OrthogonalMovement.LeftRight.canceled += _ => OnStopMovementAction();
                inputActions.OrthogonalMovement.Trigger.performed += _ => OnBoardTriggerAction();
                inputActions.OrthogonalMovement.Trigger.canceled += _ => OnStopBoardTriggerAction();
            }
            else
            {
                inputActions.Movement.Move.performed += _ => OnMoveDirectionAction();
                inputActions.Movement.Trigger.performed += _ => OnBattleTriggerAction();
                inputActions.Movement.Trigger.canceled += _ => OnStopBattleTriggerAction();
            }

        }

        private void OnDisable()
        {
            if (isOrthogonalMovement)
            {
                inputActions.OrthogonalMovement.UpDown.performed -= _ => OnUpDownAction();
                inputActions.OrthogonalMovement.UpDown.canceled -= _ => OnStopMovementAction();
                inputActions.OrthogonalMovement.LeftRight.performed -= _ => OnLeftRightAction();
                inputActions.OrthogonalMovement.LeftRight.canceled -= _ => OnStopMovementAction();
                inputActions.OrthogonalMovement.Trigger.performed -= _ => OnBoardTriggerAction();
                inputActions.OrthogonalMovement.Trigger.canceled -= _ => OnStopBoardTriggerAction();
            }
            else
            {
                inputActions.Movement.Move.performed -= _ => OnMoveDirectionAction();
                inputActions.Movement.Trigger.performed -= _ => OnBattleTriggerAction();
                inputActions.Movement.Trigger.canceled -= _ => OnStopBattleTriggerAction();
            }

            inputActions.Disable();
        }


        void OnStopMovementAction()
        {
            moveVector = Vector3.zero;
        }


        void OnMoveDirectionAction()
        {
            Vector2 moveInput = inputActions.Movement.Move.ReadValue<Vector2>();
            moveVector.x = moveInput.x;
            moveVector.z = moveInput.y;
        }


        void OnUpDownAction()
        {
            float moveInput = inputActions.OrthogonalMovement.UpDown.ReadValue<float>();
            moveVector.x = 0f;
            moveVector.z = moveInput;
        }


        void OnLeftRightAction()
        {
            float moveInput = inputActions.OrthogonalMovement.LeftRight.ReadValue<float>();
            moveVector.x = moveInput;
            moveVector.z = 0f;
        }

        void OnBattleTriggerAction()
        {
            isPressingTriggerBattle = true;
        }

        void OnBoardTriggerAction()
        {

        }

        void OnStopBattleTriggerAction()
        {
            isPressingTriggerBattle = false;
        }

        void OnStopBoardTriggerAction()
        {

        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jam
{
    public class PlayerInputHandler : MonoBehaviour, IInputHandler
    {
        [SerializeField] bool isOrthogonalMovement = true;

        PlayerInputMap inputActions;

        Vector3 m_moveVector;
        bool m_isPressingTriggerBoard;
        bool m_isPressingTriggerBattle;

        public Vector3 moveVector { get { return m_moveVector; } }
        public bool isPressingTriggerBoard { get { return m_isPressingTriggerBoard; } }
        public bool isPressingTriggerBattle { get { return m_isPressingTriggerBattle; } }


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
            m_moveVector = Vector3.zero;
        }


        void OnMoveDirectionAction()
        {
            Vector2 moveInput = inputActions.Movement.Move.ReadValue<Vector2>();
            m_moveVector.x = moveInput.x;
            m_moveVector.z = moveInput.y;
        }


        void OnUpDownAction()
        {
            float moveInput = inputActions.OrthogonalMovement.UpDown.ReadValue<float>();
            m_moveVector.x = 0f;
            m_moveVector.z = moveInput;
        }


        void OnLeftRightAction()
        {
            float moveInput = inputActions.OrthogonalMovement.LeftRight.ReadValue<float>();
            m_moveVector.x = moveInput;
            m_moveVector.z = 0f;
        }

        void OnBattleTriggerAction()
        {
            m_isPressingTriggerBattle = true;
        }

        void OnBoardTriggerAction()
        {
            m_isPressingTriggerBoard = true;
        }

        void OnStopBattleTriggerAction()
        {
            m_isPressingTriggerBattle = false;
        }

        void OnStopBoardTriggerAction()
        {
            m_isPressingTriggerBoard = false;
        }

    }
}

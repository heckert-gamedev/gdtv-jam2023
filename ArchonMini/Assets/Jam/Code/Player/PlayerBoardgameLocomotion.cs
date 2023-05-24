using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jam
{
    public class PlayerBoardgameLocomotion : MonoBehaviour
    {
        [SerializeField] float moveSpeed = 1f;

        [Tooltip("Small delay after having moved before new input is accepted")]
        [SerializeField] float movedDelay = .1f;

        [SerializeField] GameFlowManager gameFlowManager;


        //Qucikhack, actually this needs to be queried from the board manager!
        [SerializeField] Vector2 gridsize = new Vector2(6, 6);


        Rigidbody rb;
        Transform playerMesh;

        PlayerInputHandler inputHandler;


        bool isMovingSelf;
        bool isMovingPiece;

        GameObject _currentPiece;
        Vector3 _moveStart;
        Vector3 _moveEnd;
        float _movePercent;

        Vector3 _inputVector;

        WaitForSeconds waitMoved;


        void Awake()
        {
            waitMoved = new WaitForSeconds(movedDelay);
            rb = GetComponent<Rigidbody>();
            playerMesh = GetComponentInChildren<Transform>();
            inputHandler = GetComponent<PlayerInputHandler>();
        }


        void Update()
        {
            if ((GameFlowState.PlayerCanMove == gameFlowManager.GameFlowState)
                || (GameFlowState.PlayerMoves == gameFlowManager.GameFlowState))
            {
                MoveSelf();
            }

            if (isMovingPiece)
            {
                MovePiece();
            }
        }


        bool MovingIsValid()
        {
            _inputVector = inputHandler.moveVector;
            if ((_inputVector.x < 0 && transform.position.x >= 1)
                || (_inputVector.x > 0 && transform.position.x < gridsize.x - 1)
                || (_inputVector.z < 0 && transform.position.z >= 1)
                || (_inputVector.z > 0 && transform.position.z < gridsize.y - 1))
            {
                _moveStart = transform.position;
                _moveEnd = transform.position + _inputVector;
                return true;
            }
            return false;
        }


        void MoveSelf()
        {
            if (GameFlowState.PlayerCanMove == gameFlowManager.GameFlowState)
            {
                if (MovingIsValid())
                {
                    gameFlowManager.SetState(GameFlowState.PlayerMoves);
                    isMovingSelf = true;
                }
                // else player feedback (SFX)
            }
            else
            if (GameFlowState.PlayerMoves == gameFlowManager.GameFlowState)
            {
                _movePercent += Time.deltaTime;//* moveSpeed;

                Vector3 moveIt = Vector3.Lerp(_moveStart, _moveEnd, _movePercent);

                rb.MovePosition(moveIt);

                // maybe another state for player finishing its move?
                if (_movePercent >= 1f)
                {
                    _inputVector = Vector2.zero;

                    StartCoroutine(FinishMove());
                }
            }
        }


        void MovePiece()
        {

        }


        IEnumerator FinishMove()
        {
            yield return waitMoved;
            Vector3 alignPosition = new Vector3((int)transform.position.x, (int)transform.position.y, (int)transform.position.z);
            rb.MovePosition(alignPosition);

            isMovingPiece = false;
            isMovingSelf = false;

            _movePercent = 0f;
            _moveStart = transform.position;
            _moveEnd = transform.position;

            gameFlowManager.SetState(GameFlowState.OpponentCanMove);
        }

    }
}

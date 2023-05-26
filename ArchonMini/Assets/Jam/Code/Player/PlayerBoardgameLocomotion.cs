using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Jam
{
    public class PlayerBoardgameLocomotion : MonoBehaviour
    {
        [SerializeField] float moveSpeed = 1f;

        [SerializeField] GameFlowManager gameFlowManager;

        //Qucikhack, actually this needs to be queried from the board manager!
        [SerializeField] Vector2 gridsize = new Vector2(6, 6);

        [SerializeField] Material defaultMaterial;
        [SerializeField] Material selectingMaterial;

        Rigidbody rb;
        Transform playerMesh;

        PlayerInputHandler inputHandler;

        GameObject _currentPiece;
        Vector3 _moveStart;
        Vector3 _moveEnd;
        float _movePercent;

        Vector3 _inputVector;

        BoardManager board;

        Vector2Int from;
        Vector2Int to;

        void Awake()
        {
            rb = GetComponent<Rigidbody>();
            playerMesh = GetComponentInChildren<Transform>();
            inputHandler = GetComponent<PlayerInputHandler>();

            board = gameFlowManager.boardInstance.GetComponent<BoardManager>();
        }


        void Update()
        {
            if(gameFlowManager.GameFlowState == GameFlowState.Idle) return;

            if((gameFlowManager.GameFlowState == GameFlowState.PlayerCanMove) || (gameFlowManager.GameFlowState == GameFlowState.PlayerMovesSelf))
            {
                MoveSelf();
            }

            if((gameFlowManager.GameFlowState == GameFlowState.PlayerSelectsMove) || (gameFlowManager.GameFlowState == GameFlowState.PlayerSelectsMoveAndMovesSelf))
            {
                SelectMove();
            }

            if((gameFlowManager.GameFlowState == GameFlowState.PlayerMovesPiece))
            {
                MovePiece();
            }
        }


        bool MovingSelfIsValid()
        {
            _inputVector = inputHandler.moveVector;
            if(_inputVector == Vector3.zero) return false;

            if((_inputVector.x < 0 && transform.position.x >= 1)
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
            if (gameFlowManager.GameFlowState == GameFlowState.PlayerCanMove)
            {
                if(inputHandler.isPressingTriggerBoard)
                {
                    SetMaterial(selectingMaterial);
                    from.x = player.x;
                    from.y = player.y;
                    StartCoroutine(DelayStateChange(GameFlowState.PlayerSelectsMove));
                }
                else
                {
                    if(MovingSelfIsValid())
                        StartCoroutine(DelayStateChange(GameFlowState.PlayerMovesSelf));
                    // else player feedback (SFX)
                }

            }
            else
            if (gameFlowManager.GameFlowState == GameFlowState.PlayerMovesSelf)
            {
                _movePercent += moveSpeed * Time.deltaTime;

                if(_movePercent >= 1f)
                {
                    _movePercent = 1f;
                    FinishMoveSelf();
                }
                else
                {
                    Vector3 moveIt = Vector3.Lerp(_moveStart, _moveEnd, _movePercent);
                    rb.MovePosition(moveIt);
                }
                
            }
        }

        void SelectMove()
        {
            if(gameFlowManager.GameFlowState == GameFlowState.PlayerSelectsMove)
            {
                if(inputHandler.isPressingTriggerBoard)
                {
                    to.x = player.x;
                    to.y = player.y;
                    if(IsValidMove())
                    {
                        SetMaterial(defaultMaterial);
                        StartCoroutine(DelayStateChange(GameFlowState.OpponentCanMove));
                    }
                }
                else
                {
                    if(MovingSelfIsValid())
                        StartCoroutine(DelayStateChange(GameFlowState.PlayerSelectsMoveAndMovesSelf));
                    // else player feedback (SFX)
                }
            }

            if(gameFlowManager.GameFlowState == GameFlowState.PlayerSelectsMoveAndMovesSelf)
            {
                _movePercent += moveSpeed * Time.deltaTime;

                if(_movePercent >= 1f)
                {
                    _movePercent = 1f;
                    FinishMoveSelf();
                }
                else
                {
                    Vector3 moveIt = Vector3.Lerp(_moveStart, _moveEnd, _movePercent);
                    rb.MovePosition(moveIt);
                }

            }
        }

        void MovePiece()
        {
            
        }

        void FinishMoveSelf()
        {
            Vector3 alignPosition = new Vector3((int)_moveEnd.x, (int)_moveEnd.y, (int)_moveEnd.z);
            rb.MovePosition(alignPosition);

            _movePercent = 0f;
            _moveStart = transform.position;
            _moveEnd = transform.position;

            gameFlowManager.SetState(GameFlowState.OpponentCanMove);
        }

        private void SetMaterial(Material material)
        {
            MeshRenderer mr = transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>();
            Material[] mats = mr.materials;
            mats[0] = material;
            mr.materials = mats;
        }

        private IEnumerator DelayStateChange(GameFlowState state)
        {
            gameFlowManager.SetState(GameFlowState.Idle);
            yield return new WaitForSeconds(0.2f);
            gameFlowManager.SetState(state);
        }

        private bool IsValidMove()
        {
            board.CheckMove(from, to);
            return true;
        }
    }
}

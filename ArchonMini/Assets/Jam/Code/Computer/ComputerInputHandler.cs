using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jam
{
    public class ComputerInputHandler : MonoBehaviour, IInputHandler
    {
        Vector3 moveVector;
        bool isPressingTriggerBoard;
        bool isPressingTriggerBattle;


        public Vector3 i_moveVector { get { return moveVector; } }
        public bool i_isPressingTriggerBoard { get { return isPressingTriggerBoard; } }
        public bool i_isPressingTriggerBattle { get { return isPressingTriggerBattle; } }

        void Awake()
        {
            moveVector = Vector3.zero;
            isPressingTriggerBoard = false;
            isPressingTriggerBattle = false;
        }

        void Start()
        {
        }

        void Update()
        {
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jam
{
    public class ComputerInputHandler : MonoBehaviour, IInputHandler
    {
        Vector3 m_moveVector;
        bool m_isPressingTriggerBoard;
        bool m_isPressingTriggerBattle;


        public Vector3 moveVector { get { return m_moveVector; } }
        public bool isPressingTriggerBoard { get { return m_isPressingTriggerBoard; } }
        public bool isPressingTriggerBattle { get { return m_isPressingTriggerBattle; } }

        void Awake()
        {
            m_moveVector = Vector3.zero;
            m_isPressingTriggerBoard = false;
            m_isPressingTriggerBattle = false;
        }

        void Start()
        {
        }

        void Update()
        {
        }
    }
}

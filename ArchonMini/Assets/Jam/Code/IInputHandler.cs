using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jam
{
    public interface IInputHandler
    {
        public Vector3 i_moveVector { get; }

        public bool i_isPressingTriggerBoard { get; }
        public bool i_isPressingTriggerBattle { get; }
    }
}

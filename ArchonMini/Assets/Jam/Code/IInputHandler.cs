using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jam
{
    public interface IInputHandler
    {
        public Vector3 moveVector { get; }

        public bool isPressingTriggerBoard { get; }
        public bool isPressingTriggerBattle { get; }
    }
}

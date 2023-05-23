using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jam
{
    public class GameFlowManager : MonoBehaviour
    {

        Fader fader;


        private void Start()
        {
            fader = FindObjectOfType<Fader>();

            // In case the scene is loaded first (for development) and we don't wait,
            // the Core prefab is spawned afterwards and fades to black...
            Invoke(nameof(FadeInForDebug), .2f);
        }


        private void FadeInForDebug()
        {
            fader.FadeIn(.05f);
        }
    }
}

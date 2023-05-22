using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Jam
{
    public class TextSizeIncreaser : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private float velocity;

        private bool increase = false;
        private float startFontSize;


        private void Start()
        {
            startFontSize = text.fontSize;
        }


        public void BeginIncrease()
        {
            increase = true;
        }


        public void ResetState()
        {
            increase = false;
            text.fontSize = startFontSize;
        }


        void Update()
        {
            if (increase)
            {
                text.fontSize += velocity * Time.deltaTime;
            }
        }
    }

}

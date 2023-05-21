using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Jam
{
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField] Button startGameButton;
        [SerializeField] Button quitGameButton;
        [SerializeField] Button creditsButton;

        [SerializeField] GameObject uiView;
        [SerializeField] TextSequencePlayer introSequence;
        [SerializeField] TextSequencePlayer creditsSequence;


        public TextSequencePlayer IntroSequence { get => introSequence; }
        public TextSequencePlayer CreditsSequence { get => creditsSequence; }

        private MySceneManager mySceneManager = null;


        private void Start()
        {
            mySceneManager = FindObjectOfType<MySceneManager>();
            //OnEnable();
        }

        private void OnEnable()
        {
            uiView.SetActive(true);
            startGameButton.onClick.AddListener(() => mySceneManager.LoadMainScene());
            quitGameButton.onClick.AddListener(() => mySceneManager.QuitGame());
            creditsButton.onClick.AddListener(() => mySceneManager.PlayCredits());
        }

        private void OnDisable()
        {
            uiView.SetActive(false);
            startGameButton.onClick.RemoveListener(() => mySceneManager.LoadMainScene());
            quitGameButton.onClick.RemoveListener(() => mySceneManager.QuitGame());
            creditsButton.onClick.RemoveListener(() => mySceneManager.PlayCredits());
        }

    }
}

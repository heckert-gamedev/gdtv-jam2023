using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Jam
{
    public class MySceneManager : MonoBehaviour
    {
        [SerializeField] private float timeToWaitForGameStart = 1f;
        [SerializeField] private float loadSceneFadeOutTime = 1f;
        [SerializeField] private float loadSceneWaitTime = 2f;
        [SerializeField] private float loadSceneFadeInTime = 1f;

        private Fader fader;

        private MainMenuUI mainMenuUI;

        //private AudioManager audioManager;

        private void Awake()
        {
            fader = FindObjectOfType<Fader>();
            //audioManager = FindObjectOfType<AudioManager>();
            HookupMenuScenePanels();
        }

        private IEnumerator Start()
        {
            fader.FadeOutImmediate();
            yield return new WaitForSeconds(timeToWaitForGameStart);
            //audioManager.PlayMenuMusic();
            //mainMenuUI.IntroSequence?.gameObject.SetActive(enabled);
            mainMenuUI.IntroSequence?.Begin(fader);
        }


        private void HookupMenuScenePanels()
        {
            mainMenuUI = FindObjectOfType<MainMenuUI>(true);
        }

        public void QuitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }


        public void ReloadCurrentScene()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            StartCoroutine(LoadScene(currentSceneIndex));
        }


        public void PlayCredits()
        {
            //audioManager.StopMusic(() => audioManager.PlayOutroMusic());

            mainMenuUI.CreditsSequence?.gameObject.SetActive(enabled);
            mainMenuUI.CreditsSequence?.Begin(fader);
        }


        public void LoadMainScene()
        {
            Debug.Log("load the dummy scene");
            StartCoroutine(LoadScene(1));
        }


        private IEnumerator LoadScene(int sceneIndex)
        {
            Cursor.lockState = CursorLockMode.Locked;

            yield return fader.FadeOut(loadSceneFadeOutTime);
            //audioManager.StopMusic(null);
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneIndex);
            while (!asyncLoad.isDone)
            {
                yield return null;
            }
            yield return new WaitForEndOfFrame();

            // When we return to the main scene we need to refresh the references for the panels.
            if (0 == sceneIndex)
            {
                Cursor.lockState = CursorLockMode.Confined;
                HookupMenuScenePanels();
            }
            yield return new WaitForSeconds(loadSceneWaitTime);
            yield return fader.FadeIn(loadSceneFadeInTime);
        }

    }
}

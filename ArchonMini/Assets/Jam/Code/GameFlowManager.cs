using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jam
{

    public enum GameFlowState { Idle, PlayerCanMove, PlayerMoves, OpponentCanMove, OpponentMoves, BattleMode }

    public class GameFlowManager : MonoBehaviour
    {

        [Header("Board and Battlefield")]
        [SerializeField] GameObject boardInstance;
        [SerializeField] GameObject battleInstance;

        [Header("Player objects")]
        [SerializeField] GameObject boardPlayer;
        [SerializeField] GameObject battlePlayer;


        GameFlowState gameFlowState = GameFlowState.Idle;

        public GameFlowState GameFlowState { get => gameFlowState; private set => gameFlowState = value; }

        Fader fader;


        private void Start()
        {
            fader = FindObjectOfType<Fader>();

            // In case the scene is loaded first (for development) and we don't wait,
            // the Core prefab is spawned afterwards and fades to black...
            Invoke(nameof(FadeInForDebug), .2f);
            Invoke(nameof(OpenSceneForBoardGame), 1f);
        }


        private void FadeInForDebug()
        {
            fader.FadeIn(.05f);
        }


        private void OpenSceneForBoardGame()
        {
            OpenSceneForBoardGame(false);
        }


        private void OpenSceneForBoardGame(bool withTransition = false)
        {
            // battleInstance?.SetActive(false);
            // battlePlayer?.SetActive(false);

            if (withTransition)
            {
                Debug.Log($"battle->board transition requested");
                // Do Transition
            }

            boardInstance?.SetActive(true);
            boardPlayer?.SetActive(true);

            //battleInstance?.BattleEnded -= _ => OnBattleEnded();
            gameFlowState = GameFlowState.PlayerCanMove;
        }


        public void OpenSceneForBattlefield()
        {
            boardInstance?.SetActive(false);
            boardPlayer?.SetActive(false);
            // Transition goes here
            //battleInstance?.SetActive(true);
            //battlePlayer?.SetActive(true);

            //battleInstance?.BattleEnded += _ => OnBattleEnded();

            gameFlowState = GameFlowState.BattleMode;
        }

        void OnBattleEnded()
        {
            // Resolve outcome

            // switch back to board game, with transition
            OpenSceneForBoardGame(true);
        }


        public void SetState(GameFlowState newFlowState)
        {
            if (
                (GameFlowState.PlayerMoves == gameFlowState && GameFlowState.OpponentCanMove == newFlowState)
                ||
                (GameFlowState.PlayerCanMove == gameFlowState && GameFlowState.PlayerMoves == newFlowState))
            {
                gameFlowState = newFlowState;
                StartCoroutine(DummyOponent()); // testing it!
                return;
            }
        }


        // Just a mock to reset the state after a moment!
        IEnumerator DummyOponent()
        {
            yield return new WaitForSeconds(1f);
            gameFlowState = GameFlowState.PlayerCanMove;
        }

    }
}

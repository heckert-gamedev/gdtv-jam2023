using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jam
{

    public enum GameFlowState { Idle, PlayerCanMove, PlayerMovesSelf, PlayerSelectsMove, PlayerSelectsMoveAndMovesSelf, PlayerMovesPiece, OpponentCanMove, OpponentMovesPiece, BattleMode }

    public class GameFlowManager : MonoBehaviour
    {

        [Header("Boards")]
        public GameObject boardInstance;
        [SerializeField] GameObject battleInstance;

        [Header("Active objects")]
        [SerializeField] GameObject boardPlayer;
        [SerializeField] GameObject battlePhase;


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
            // Unsubscribe event
            BattleHandler.battleEnded -= OnBattleEnded;

            battlePhase?.SetActive(false);
            battleInstance?.SetActive(false);

            boardInstance?.SetActive(true);
            boardPlayer?.SetActive(true);

            if (withTransition)
            {
                Debug.Log($"battle->board transition requested");
                // Do Transition
            }
            
            SetState(GameFlowState.PlayerCanMove);
        }


        public void OpenSceneForBattlefield(bool withTransition = false)
        {
            // Subscribe event
            BattleHandler.battleEnded += OnBattleEnded;

            boardInstance?.SetActive(false);
            boardPlayer?.SetActive(false);

            battlePhase?.SetActive(true);
            battleInstance?.SetActive(true);

            if(withTransition)
            {
                Debug.Log($"board->battle transition requested");
                // Do Transition
            }

            SetState(GameFlowState.BattleMode);
        }

        void OnBattleEnded()
        {
            // Resolve outcome

            // Switch back to board game, with transition
            OpenSceneForBoardGame(true);
        }


        public void SetState(GameFlowState newFlowState)
        {
            gameFlowState = newFlowState;
            if(gameFlowState == GameFlowState.OpponentCanMove)
            {
                gameFlowState = GameFlowState.PlayerCanMove;
                //StartCoroutine(DummyOpponent());
            }
        }


        // Just a mock to reset the state after a moment!
        IEnumerator DummyOpponent()
        {
            yield return new WaitForSeconds(1f);
            gameFlowState = GameFlowState.PlayerCanMove;
        }

    }
}

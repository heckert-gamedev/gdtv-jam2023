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

        [Header("Settings")]
        [SerializeField] bool startInBattle;

        GameFlowState gameFlowState = GameFlowState.Idle;

        public GameFlowState GameFlowState { get => gameFlowState; private set => gameFlowState = value; }

        Fader fader;

        Vector2Int piece1;
        Vector2Int piece2;

        public AudioSource audioSource;

        public AudioClip winBattleClip;
        public AudioClip loseBattleClip;
        public AudioClip loseGameClip;
        public AudioClip attackClip;
        public AudioClip selectPieceClip;
        public AudioClip movePieceClip;


        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
            fader = FindObjectOfType<Fader>();

            // In case the scene is loaded first (for development) and we don't wait,
            // the Core prefab is spawned afterwards and fades to black...
            Invoke(nameof(FadeInForDebug), .2f);
            //Invoke(nameof(OpenSceneForBoardGame), 1f);

            if(startInBattle)
                OpenSceneForBattlefield(new Vector2Int(0, 0), new Vector2Int(0,7));
            else
                OpenSceneForBoardGame();
        }


        private void FadeInForDebug()
        {
            fader.FadeIn(.05f);
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


        public void OpenSceneForBattlefield(Vector2Int piece1, Vector2Int piece2, bool withTransition = false)
        {
            this.piece1 = piece1;
            this.piece2 = piece2;
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
            //Debug.Log("on battle ended");
            BattleHandler battleHandler = battlePhase?.GetComponent<BattleHandler>();
            BoardManager boardManager = boardInstance.GetComponent<BoardManager>();
            if(battleHandler.state == BattleHandler.BattleState.PlayerWon)
            {
                boardManager.RemovePiece(piece2);
                boardManager.MovePiece(piece1, piece2);
                battleHandler.state = BattleHandler.BattleState.Fighting;
                SetState(GameFlowState.OpponentCanMove);
            }
            else if (battleHandler.state == BattleHandler.BattleState.PlayerLost)
            {
                boardManager.RemovePiece(piece1);
                boardManager.MovePiece(piece2, piece1);
                SetState(GameFlowState.OpponentCanMove);
            }

            // Switch back to board game, with transition
            OpenSceneForBoardGame(false);
        }


        public void SetState(GameFlowState newFlowState)
        {
            gameFlowState = newFlowState;
            if(gameFlowState == GameFlowState.OpponentCanMove)
            {
                gameFlowState = GameFlowState.PlayerCanMove;
            }
        }


        // Just a mock to reset the state after a moment!
        IEnumerator DummyOpponent()
        {
            yield return new WaitForSeconds(1f);
            gameFlowState = GameFlowState.PlayerCanMove;
        }

        public void PlayClip(AudioClip clip)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }

    }
}

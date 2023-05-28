using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jam
{
    public class BattleHandler : MonoBehaviour
    {

        public delegate void BattleEnded();
        public static event BattleEnded battleEnded;

        public enum BattleState {
            Idle, Fighting, PlayerWon, PlayerLost, Draw
        }

        public BattleState state;
        [SerializeField] GameObject firstCombatant;
        [SerializeField] GameObject secondCombatant;

        [SerializeField] GameFlowManager gameFlowManager;

        Vector3 originalFirstPos;
        Vector3 originalSecondPos;

        private void OnEnable()
        {
            StartBattle();
        }

        private void Awake()
        {
            state = BattleState.Idle;
            firstCombatant.GetComponent<Combatant>().battleHandler = this;
            secondCombatant.GetComponent<Combatant>().battleHandler = this;
            originalFirstPos = firstCombatant.transform.position;
            originalSecondPos = secondCombatant.transform.position;
        }

        private void Start()
        {
            //StartBattle();
        }

        private void Update()
        {
            //Debug.Log(state);
        }

        private void StartBattle()
        {
            firstCombatant.transform.position = originalFirstPos;
            secondCombatant.transform.position = originalSecondPos;
            firstCombatant.GetComponent<Combatant>().SetHealth(10f);
            secondCombatant.GetComponent<Combatant>().SetHealth(10f);
            state = BattleState.Fighting;
        }

        public void EndBattle(BattleState state)
        {
            this.state = state;
            StartCoroutine(waitAndEnd());
        }

        private IEnumerator waitAndEnd()
        {
            yield return new WaitForSeconds(0.25f);
            battleEnded?.Invoke();
        }


    }
}

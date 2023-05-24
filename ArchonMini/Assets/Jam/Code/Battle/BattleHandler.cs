using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jam
{
    public class BattleHandler : MonoBehaviour
    {

        public enum BattleState {
            Idle, Fighting, PlayerWon, PlayerLost, Draw
        }

        public BattleState state;
        [SerializeField] GameObject firstCombatant;
        [SerializeField] GameObject secondCombatant;

        private void Awake()
        {
            state = BattleState.Idle;
            firstCombatant.GetComponent<Combatant>().battleHandler = this;
            secondCombatant.GetComponent<Combatant>().battleHandler = this;
        }

        private void Start()
        {
            StartBattle();
        }

        private void Update()
        {
        }

        private void StartBattle()
        {
            state = BattleState.Fighting;
        }

        public void EndBattle(BattleState state)
        {
            this.state = state;
        }


    }
}

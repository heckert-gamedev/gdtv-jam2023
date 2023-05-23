using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jam
{
    public class BattlePhase : MonoBehaviour
    {
        [SerializeField] GameObject player;
        [SerializeField] GameObject enemy;
        [SerializeField] float playerHealth;
        [SerializeField] float enemyHealth;

        PlayerInputHandler inputHandler;

        // Awake is called when the script object is initialized
        private void Awake()
        {
            inputHandler = player.GetComponent<PlayerInputHandler>();
        }

        // Start is called before the first frame update
        private void Start()
        {
            
        }

        // Update is called once per frame
        private void Update()
        {
            if(inputHandler.isAttemptingAttack)
            {
                PlayerAttack();
            }
        }

        private void PlayerAttack()
        {
            DamageEnemy();
            inputHandler.StopAttemptingAttack();
        }

        private void EnemyAttack()
        {
            DamagePlayer();
        }

        private void DamagePlayer()
        {

        }

        private void DamageEnemy()
        {

        }

        
    }
}

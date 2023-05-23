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
        [SerializeField] Material playerMaterial;
        [SerializeField] Material enemyMaterial;
        [SerializeField] Material damageMaterial;

        PlayerInputHandler inputHandler;

        bool isPlayerAttacking = false;
        bool isEnemyAttacking = false;

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
            if(inputHandler.isPressingTriggerBattle)
            {
                PlayerAttack();
            }
        }

        private void PlayerAttack()
        {
            if(isPlayerAttacking) return;
            isPlayerAttacking = true;
            DamageEnemy();
            isPlayerAttacking = false;
        }
        

        private void DamageEnemy()
        {
            StartCoroutine(HurtEnemyAnimation());
        }


        private void DamagePlayer()
        {
            StartCoroutine(HurtPlayerAnimation());
        }

        private void EnemyAttack()
        {
            DamagePlayer();
        }

        
        private IEnumerator HurtPlayerAnimation()
        {
            MeshRenderer mr = player.GetComponent<MeshRenderer>();
            Material[] mats = mr.materials;
            mats[0] = damageMaterial;
            mr.materials = mats;
            yield return new WaitForSeconds(0.5f);
            mats[0] = playerMaterial;
            mr.materials = mats;
        }

        private IEnumerator HurtEnemyAnimation()
        {
            MeshRenderer mr = enemy.GetComponent<MeshRenderer>();
            Material[] mats = mr.materials;
            mats[0] = damageMaterial;
            mr.materials = mats;
            yield return new WaitForSeconds(0.5f);
            mats[0] = enemyMaterial;
            mr.materials = mats;
        }


    }
}

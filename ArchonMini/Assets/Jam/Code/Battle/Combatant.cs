using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jam
{
    public class Combatant : MonoBehaviour
    {
        [SerializeField] float health;
        [SerializeField] Material material;
        [SerializeField] Material hurtMaterial;
        [SerializeField] bool isPlayer;
        bool isAttacking;
        
        IInputHandler inputHandler;

        public BattleHandler battleHandler;

        private void Awake()
        {
            if(isPlayer) inputHandler = GetComponent<PlayerInputHandler>();
            else inputHandler = GetComponent<ComputerInputHandler>();
        }

        void Start()
        {
        }

        void Update()
        {
            if(inputHandler.i_isPressingTriggerBattle)
            {
                Attack();
            }
        }

        private IEnumerator HurtAnimation()
        {
            MeshRenderer mr = GetComponent<MeshRenderer>();
            Material[] mats = mr.materials;
            mats[0] = hurtMaterial;
            mr.materials = mats;
            yield return new WaitForSeconds(0.5f);
            mats[0] = material;
            mr.materials = mats;
        }

        private void TakeDamage(float damage)
        {
            health -= damage;
            StartCoroutine(HurtAnimation());
            if(health <= 0f) Debug.Log("Battle end");
        }

        private void Attack()
        {
            if(isAttacking) return;
            isAttacking = true;
            //DamageEnemy(enemy);
            isAttacking = false;
        }
    }
}

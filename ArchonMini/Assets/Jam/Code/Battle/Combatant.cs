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
        
        IInputHandler inputHandler;

        public BattleHandler battleHandler;

        public GameObject attackBox;

        bool canAttack;

        private void Awake()
        {
            if(isPlayer) inputHandler = GetComponent<PlayerInputHandler>();
            else inputHandler = GetComponent<ComputerInputHandler>();
            attackBox = transform.GetChild(0).gameObject;
            canAttack = true;
        }

        private void OnEnable()
        {
            canAttack = true;

        }

        void Start()
        {
        }

        void Update()
        {
            if(battleHandler.state != BattleHandler.BattleState.Fighting) return;

            if (inputHandler.isPressingTriggerBattle)
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
            yield return new WaitForSeconds(0.25f);
            mats[0] = material;
            mr.materials = mats;
        }

        public void TakeDamage(float damage)
        {
            health -= damage;
            StartCoroutine(HurtAnimation());
            if(health <= 0f)
            {
                battleHandler.EndBattle(isPlayer ? BattleHandler.BattleState.PlayerLost : BattleHandler.BattleState.PlayerWon);
            }
        }

        IEnumerator DisableAttackBox()
        {
            yield return new WaitForSeconds(0.05f);
            attackBox.SetActive(false);
        }

        IEnumerator AttackCooldown(float time)
        {
            yield return new WaitForSeconds(time);
            canAttack = true;
        }

        private void Attack()
        {
            if(!canAttack) return;
            if (attackBox.activeSelf) return;
            attackBox.SetActive(true);
            canAttack = false;
            StartCoroutine(DisableAttackBox());
            StartCoroutine(AttackCooldown(1f));
        }

        public void SetHealth(float health)
        {
            this.health = health;
        }
    }
}

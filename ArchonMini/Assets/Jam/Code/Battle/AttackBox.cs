using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jam
{
    public class AttackBox : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {

            // Perform actions on the enemy, such as dealing damage
            Combatant otherCombatant = other.GetComponent<Combatant>();
            if(otherCombatant != null)
            {
                otherCombatant.TakeDamage(1f);
            }
            
        }
    }
}

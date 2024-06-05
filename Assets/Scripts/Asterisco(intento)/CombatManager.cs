using System.Collections;
using UnityEngine;
using System.Collections.Generic;
public class CombatManager : MonoBehaviour
{
    public PlayerAttributes player;
    private EnemyAttributes enemy;
    private bool inCombat = false;
    public GameObject combatPopup;

    public void StartCombat(EnemyAttributes enemyAttributes)
    {
        if (inCombat)
            return;

        inCombat = true;
        enemy = enemyAttributes;
        combatPopup.SetActive(true);
        StartCoroutine(CombatCoroutine());
    }

    private IEnumerator CombatCoroutine()
    {
        while (player.CurrentHealth > 0 && enemy.CurrentHealth > 0)
        {
            enemy.CurrentHealth -= player.CurrentDamage;
            yield return new WaitForSeconds(1f);

            if (enemy.CurrentHealth <= 0)
                break;

            player.CurrentHealth -= enemy.CurrentDamage;
            yield return new WaitForSeconds(1.5f);
        }

        EndCombat();
    }

    private void EndCombat()
    {
        inCombat = false;
        combatPopup.SetActive(false);

        // Si el jugador pierde
        if (player.CurrentHealth <= 0)
        {
            Debug.Log("Game Over");
        }
        else if (enemy.CurrentHealth <= 0)
        {
            player.GainExp(3);
            DropItem();
        }
    }

    private void DropItem()
    {

    }
}



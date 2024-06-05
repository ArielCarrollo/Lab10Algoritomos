using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public Player player;
    public GameObject enemyPrefab;
    public List<Enemy> enemies;

    void Start()
    {
        enemies = new List<Enemy>();
        SpawnEnemies();
        StartCoroutine(BattleRoutine());
    }

    void SpawnEnemies()
    {
        SpawnEnemy(1);
        SpawnEnemy(2);
    }

    void SpawnEnemy(int level)
    {
        GameObject enemyObj = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        Enemy enemy = enemyObj.GetComponent<Enemy>();
        enemy.Initialize(level);
        enemies.Add(enemy);
    }

    public void RemoveEnemy(Enemy enemy)
    {
        if (enemies.Contains(enemy))
        {
            enemies.Remove(enemy);
            Destroy(enemy.gameObject);
        }
    }

    IEnumerator BattleRoutine()
    {
        while (player.currentHp > 0 && enemies.Count > 0)
        {
            for (int i = enemies.Count - 1; i >= 0; i--)
            {
                if (enemies[i] != null)
                {
                    // Player attacks enemy
                    player.Attack();
                    yield return new WaitForSeconds(player.attackSpeed / 2); 
                    enemies[i].TakeDamage(player.damage);
                    Debug.Log($"Enemy HP: {enemies[i].currentHp}");

                    if (enemies[i].currentHp <= 0)
                    {
                        player.GainExp(3);
                        RemoveEnemy(enemies[i]);
                        continue;
                    }

                    yield return new WaitForSeconds(player.attackSpeed / 2);
                    enemies[i].Attack();
                    yield return new WaitForSeconds(enemies[i].attackSpeed / 2); 
                    player.TakeDamage(enemies[i].damage);
                    Debug.Log($"Player HP: {player.currentHp}");

                    if (player.currentHp <= 0)
                    {
                        Debug.Log("Enemy wins!");
                        yield break;
                    }

                    yield return new WaitForSeconds(enemies[i].attackSpeed / 2);
                }
            }
        }

        if (player.currentHp > 0)
        {
            Debug.Log("Player wins!");
        }
    }
}

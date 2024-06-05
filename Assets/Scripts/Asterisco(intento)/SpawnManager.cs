using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject[] itemPrefabs;
    public List<Vector3> path;

    void Start()
    {
        SpawnEnemies(1);
        SpawnItems();
    }

    void SpawnEnemies(int level)
    {
        if (level == 1)
        {
            SpawnEnemy(1);
            SpawnEnemy(2);
        }
        else
        {
            for (int i = 0; i < level; i++)
            {
                int enemyLevel = Random.Range(1, 4);
                SpawnEnemy(enemyLevel);
            }
        }
    }

    void SpawnEnemy(int level)
    {
        Vector3 spawnPosition = path[Random.Range(0, path.Count)];
        GameObject enemyObject = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        EnemyAttributes enemyAttributes = enemyObject.GetComponent<EnemyAttributes>();
        enemyAttributes.SetLevel(level);
    }
    void SpawnItems()
    {
        foreach (GameObject itemPrefab in itemPrefabs)
        {
            Vector3 spawnPosition = path[Random.Range(0, path.Count)];
            Instantiate(itemPrefab, spawnPosition, Quaternion.identity);
        }
    }
}

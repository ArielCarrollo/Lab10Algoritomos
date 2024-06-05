using UnityEngine;

public class EnemyAttributes : MonoBehaviour
{

    public int baseHealth = 5;
    public int level = 1;
    public int baseDamage = 1;

    public int CurrentHealth;
    public int CurrentDamage; 

    void Start()
    {

        UpdateStats();
    }


    public void SetLevel(int newLevel)
    {
        level = newLevel;
        UpdateStats();
    }

    private void UpdateStats()
    {
        CurrentHealth = baseHealth * level;
        CurrentDamage = baseDamage * level;
    }
}

using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    public int baseHealth = 10;
    public int level = 1;
    public int baseDamage = 2;
    public int experience = 0;
    public int experienceToLevelUp = 10;

    public int CurrentHealth;
    public int CurrentDamage; 

    void Start()
    {
        UpdateStats();
    }

    public void UpdateStats()
    {
        CurrentHealth = baseHealth * level;
        CurrentDamage = baseDamage * level;
    }

    public void GainExp(int amount)
    {
        experience += amount;
        if (experience >= experienceToLevelUp)
        {
            level++;
            experience = 0;
            UpdateStats();
        }
    }
    public void ResetStats()
    {
        UpdateStats();
    }
}

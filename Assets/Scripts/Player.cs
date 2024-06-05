using UnityEngine;

public class Player : MonoBehaviour
{
    public int baseHealth = 10;
    public int baseDamage = 2;
    public int level = 1;
    public int currentExp = 0;
    public int expToNextLevel = 10;
    public int currentHp;
    public int damage;
    public float attackSpeed = 1.0f;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        CalculateStats();
    }

    void CalculateStats()
    {
        currentHp = baseHealth * level;
        damage = baseDamage * level;
    }

    public void GainExp(int amount)
    {
        currentExp += amount;
        if (currentExp >= expToNextLevel)
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        level++;
        currentExp = 0;
        CalculateStats();
        Debug.Log("Player leveled up! New level: " + level);
    }

    public void TakeDamage(int amount)
    {
        currentHp -= amount;
        if (currentHp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
       
        Debug.Log("Player has died.");
    }

    public void Attack()
    {
        if (animator != null)
        {
            animator.SetTrigger("Attack");
        }
    }
}

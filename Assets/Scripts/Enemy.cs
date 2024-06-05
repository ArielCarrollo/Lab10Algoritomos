using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int baseHealth = 5;
    public int baseDamage = 1;
    public int level;
    public int currentHp;
    public int damage;
    public float attackSpeed = 1.5f;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Initialize(int enemyLevel)
    {
        level = enemyLevel;
        currentHp = baseHealth * level;
        damage = baseDamage * level;
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
        
        Debug.Log("Enemy has died.");
        Destroy(gameObject);
    }

    public void Attack()
    {
        if (animator != null)
        {
            animator.SetTrigger("Attack");
        }
    }
}

using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [Tooltip("Health")][SerializeField] private float health = 100f;

    public void TakeDamage(float damage)
    {
        health = health - damage;
        Debug.Log("Health:" + health);
        if (health <= 0)
        {
            
            Debug.Log("Death");
        }
    }
}

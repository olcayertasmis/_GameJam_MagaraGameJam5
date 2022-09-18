using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private int health;
    public int roomNumber;
    public bool isDead;

    public void TakeDamage(int damage)
    {
        if (health > 0)
        {
            health -= damage;
        }
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;
        // Animation
    }

}

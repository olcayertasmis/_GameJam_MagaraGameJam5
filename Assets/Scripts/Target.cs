using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int roomNumber;

    public void TakeDamage(int damage)
    {
        if (health > 0)
        {
            health -= damage;
        }
        else if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Animation
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private int health;
    public int roomNumber;
    public bool isDead;
    [SerializeField] private AudioSource source;
    [SerializeField] private List<AudioClip> painSound;
    [SerializeField] private bool isMan;


    public void TakeDamage(int damage)
    {
        if (health > 0)
        {
            health -= damage;
        }
        if (health <= 0)
        {
            if (painSound.Count != 0)
            {
                PlaySound();
            }
            Die();
        }
    }

    private void PlaySound()
    {
        if (isMan)
        {
            source.PlayOneShot(painSound[0]);
        }
        if (!isMan)
        {
            source.PlayOneShot(painSound[1]);
        }
    }
    private void Die()
    {
        isDead = true;
        // Animation
    }

}

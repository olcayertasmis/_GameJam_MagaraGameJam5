using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolShooting : MonoBehaviour, IUsable
{
    [SerializeField] private int damage;
    AudioSource source;
    [SerializeField] private List<AudioClip> bulletSound;


    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void Use()
    {

        Shoot();

    }

    private void Shoot()
    {
        GameObject targetRaycaster = GetComponentInParent<PlayerRaycaster>().RaycastFromCamera("Target");

        if (targetRaycaster != null && targetRaycaster.GetComponent<Target>() != null)
        {
            targetRaycaster.GetComponentInParent<Target>().TakeDamage(damage);
        }

        int randomSound = Random.Range(0, bulletSound.Count - 1);
        source.PlayOneShot(bulletSound[randomSound]);
    }
}

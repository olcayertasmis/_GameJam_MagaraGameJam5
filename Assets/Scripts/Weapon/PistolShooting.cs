using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolShooting : MonoBehaviour
{
    [SerializeField] private int damage;

    [SerializeField] private PlayerRaycaster playerRaycaster;
    [SerializeField] private Target target;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject targetRaycaster = playerRaycaster.RaycastFromCamera();
        
        if (targetRaycaster != null)
        {
            target.TakeDamage(damage);
        }
    }
}

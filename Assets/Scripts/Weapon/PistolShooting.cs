using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolShooting : MonoBehaviour, IUsable //#TODO silah alimiyla aktiflestir / Corpyr
{
    //public PlayerInputReciver playerInputReciver;
    [SerializeField] private int damage;
    [SerializeField] private PlayerRaycaster playerRaycaster;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    public void Use(){

        

    }

    private void Shoot()
    {
        GameObject targetRaycaster = playerRaycaster.RaycastFromCamera();
        
        if (targetRaycaster != null && targetRaycaster.GetComponent<Target>() != null)
        {
            targetRaycaster.GetComponent<Target>().TakeDamage(damage);
        }
    }
}

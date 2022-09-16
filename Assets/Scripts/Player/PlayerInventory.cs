using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public GameObject objectInHand;
    public PlayerRaycaster raycaster;

    public void Pickup(){

        GameObject tempObject = raycaster.RaycastFromCamera();
        
        if(tempObject != null){
            objectInHand = tempObject;
            _takeObjectToHand();
        }

    }

    private void _takeObjectToHand(){ //#TODO bunu ele gore degistirecegiz / Corpyr

        objectInHand.transform.parent = transform;
        objectInHand.transform.position = transform.position;

    }
}

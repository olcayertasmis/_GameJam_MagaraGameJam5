using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public GameObject objectInHand;
    public List<GameObject> inventory;
    public PlayerRaycaster raycaster;

    public void Pickup(){

        GameObject tempObject = raycaster.RaycastFromCamera();
        
        if(tempObject != null){

            objectInHand = tempObject;
            inventory.Add(objectInHand);

            _takeObjectToHand();
            _deactiveInventory();
        
        }

    }

    public void PlaceObject(){

        //#TODO bomba gibi seyleri yerlestirme kismi / Corpyr

    }

    private void _takeObjectToHand(){ //#TODO pozisyon ve parent ele gore degisecek / Corpyr

        objectInHand.tag = "Untagged";
        objectInHand.transform.parent = transform;
        objectInHand.transform.position = transform.position;

    }

    private void _deactiveInventory(){

        foreach(GameObject gameObject in inventory){

            if(gameObject.name != objectInHand.name){

                gameObject.SetActive(false);
            
            }

        }

    }

}

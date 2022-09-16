using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [Header("Runtime Variables")]
    [Space(5f)]
    public GameObject objectInHand;
    public List<GameObject> inventory;
    [Space(10f)]
    public Transform itemGrabTransform; //Gecici el / Corpyr
    public PlayerRaycaster raycaster;

    private float timer = 5f;

    public void UseObjectInHand(){

        if(objectInHand != null){
            
            objectInHand.GetComponent<IUsable>().Use();
        
        }

    }

    public void Pickup()
    {

        GameObject tempObject = raycaster.RaycastFromCamera("Pickupable");

        if (tempObject != null)
        {

            objectInHand = tempObject;
            inventory.Add(objectInHand);

            _takeObjectToHand();
            _deactiveInventory();

        }

    }

    public bool PlaceObjectControl()
    {
        GameObject bombRaycaster = raycaster.RaycastFromCamera("BombArea");

        if (bombRaycaster != null && bombRaycaster.gameObject.tag == "BombArea")
        {
            var bombControl = objectInHand.GetComponent<Bomb>(); //#FIXME null hatasi veriyor / Corpyr
            if (bombControl != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }

    public void PlaceObject()
    {
        GameObject placeRaycaster = raycaster.RaycastFromCamera("BombArea");
        GameObject bombObject = objectInHand;
        bombObject.transform.position = placeRaycaster.gameObject.transform.position;
        Destroy(objectInHand);
    }


    private void _takeObjectToHand()
    { 

        objectInHand.tag = "Untagged";
        objectInHand.transform.parent = itemGrabTransform.transform; 
        objectInHand.transform.position = itemGrabTransform.transform.position;

    }

    private void _deactiveInventory()
    {

        foreach (GameObject gameObject in inventory)
        {

            if (gameObject.name != objectInHand.name)
            {

                gameObject.SetActive(false);

            }

        }

    }

}

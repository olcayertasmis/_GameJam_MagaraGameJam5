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
    public PlayerRaycaster raycaster;

    private void Update()
    {

    }
    public void UseObjectInHand()
    {

        if (objectInHand != null)
        {

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
            var bombControl = objectInHand.GetComponentInChildren<Bomb>();
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

        objectInHand.transform.position = placeRaycaster.gameObject.transform.position;
        objectInHand.transform.SetParent(null);
        inventory.Remove(objectInHand);
        objectInHand = null;
    }


    private void _takeObjectToHand()
    { //#TODO pozisyon ve parent ele gore degisecek / Corpyr

        objectInHand.tag = "Untagged";
        objectInHand.transform.parent = transform;
        objectInHand.transform.position = transform.position;

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

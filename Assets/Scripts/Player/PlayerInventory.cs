using System;
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
    public bool isPlaced;

    [SerializeField] private DoorEventControl doorEventControl;

    private void Start()
    {
        //doorEventControl.SayiChanged += doorEventControl_SayiChanged;
    }

    private void doorEventControl_SayiChanged(int a, string b)
    {
        if (b == "-")
        {
            print("Sayi azaltildi. " + a);
        }
        else
        {
            print("Sayi yukseltildi. " + a);
        }
    }

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

        if (tempObject != null && tempObject.gameObject.tag == "Pickupable")
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
        if (objectInHand != null)
        {
            var bombControl = objectInHand.GetComponentInChildren<Bomb>();
            if (bombControl != null && bombRaycaster != null && bombRaycaster.gameObject.tag == "BombArea")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    public void PlaceObject()
    {
        // print(PlaceObjectControl());
        //&& PlaceObjectControl() == true
        GameObject placeRaycaster = raycaster.RaycastFromCamera("BombArea");

        if (placeRaycaster != null)
        {
            objectInHand.transform.position = placeRaycaster.gameObject.transform.position;
            objectInHand.transform.SetParent(null);
            inventory.Remove(objectInHand);
            objectInHand = inventory[0];

            objectInHand.SetActive(true);

            isPlaced = true;
        }
    }


    private void _takeObjectToHand()
    {

        objectInHand.tag = "Untagged";
        objectInHand.transform.parent = itemGrabTransform.transform;
        objectInHand.transform.position = itemGrabTransform.transform.position;
        objectInHand.transform.rotation = itemGrabTransform.transform.rotation;

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

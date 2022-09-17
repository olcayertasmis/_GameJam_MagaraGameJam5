using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIChanger : MonoBehaviour
{
    [SerializeField] private GameObject pickupCanvas;
    [SerializeField] private GameObject plantCanvas;
    [SerializeField] private PlayerInventory playerInventory;

    public void ShowPickupInfo()
    {

        pickupCanvas.SetActive(true);

    }

    public void ShowPlantInfo()
    {
        if(playerInventory.objectInHand != null && playerInventory.objectInHand.GetComponent<Bomb>() != null) plantCanvas.SetActive(true);

    }

    private void Update()
    {

        pickupCanvas.SetActive(false);
        plantCanvas.SetActive(false);

    }
}

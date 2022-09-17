using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIChanger : MonoBehaviour
{
    [SerializeField] private GameObject pickupCanvas;
    [SerializeField] private GameObject plantCanvas;

    public void ShowPickupInfo()
    {

        pickupCanvas.SetActive(true);

    }

    public void ShowPlantInfo()
    {

        plantCanvas.SetActive(true);

    }

    private void Update()
    {

        pickupCanvas.SetActive(false);
        plantCanvas.SetActive(false);

    }
}

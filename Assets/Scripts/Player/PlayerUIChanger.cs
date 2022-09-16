using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIChanger : MonoBehaviour
{
    [SerializeField] private GameObject canvas;

    public void ShowPickupInfo()
    {

        canvas.SetActive(true);

    }

    private void Update()
    {

        canvas.SetActive(false);

    }
}

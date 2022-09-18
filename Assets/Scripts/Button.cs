using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Button : MonoBehaviour
{
    public PlayerRaycaster raycaster;
    [SerializeField] private TriggerFall triggerFall;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            PushButton();
        }
    }

    public void PushButton()
    {
        GameObject tempObject = raycaster.RaycastFromCamera("Button");

        if (tempObject != null && tempObject.tag == "Button")
        {
            print("girdim");
            triggerFall.UnfreezeRigidbody();
        }
    }
}

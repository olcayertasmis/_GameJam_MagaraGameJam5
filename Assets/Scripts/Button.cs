using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Button : MonoBehaviour
{
    [SerializeField] public UnityEvent inputEvent;
    public PlayerRaycaster raycaster;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inputEvent != null)
        {
            inputEvent.Invoke();
        }
    }

    public void PushButton()
    {
        GameObject tempObject = raycaster.RaycastFromCamera("Button");

        if (tempObject != null && tempObject.tag == "Button")
        {
            print("Butonum"); // Buraya istenen fonksiyonları çağırma yazılacak
        }
    }
}

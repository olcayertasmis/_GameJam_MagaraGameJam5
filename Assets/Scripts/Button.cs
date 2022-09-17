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

    public void Bomb()
    {
        GameObject tempObject = raycaster.RaycastFromCamera("BombButton");

        if (tempObject != null && tempObject.tag == "BombButton")
        {
            print("Bombayım");
        }
    }
}

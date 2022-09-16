using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInputReciver : MonoBehaviour
{
    [SerializeField]
    public UnityEvent inputEvent;

    private float timer = 5f;

    [SerializeField] private PlayerInventory playerInventory;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

            inputEvent.Invoke();

        }
        
        if (Input.GetKeyDown(KeyCode.F) && playerInventory.PlaceObjectControl())
        {
            timer -= Time.deltaTime;
            if (timer == 0)
            {
                playerInventory.PlaceObject();
            }
        }
        else if (Input.GetKeyUp(KeyCode.F))
        {
            timer = 5f;
        }
    }
}

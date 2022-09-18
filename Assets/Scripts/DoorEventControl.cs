using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEventControl : MonoBehaviour
{
    [SerializeField] private DoorEvent[] doorEvents;
    [SerializeField] private int currentRoom;
    [SerializeField] private PlayerRaycaster raycaster;
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private TriggerFall triggerFall;
    [SerializeField] private Bomb bomb;

    void Update()
    {
        switch (currentRoom)
        {
            case 0:
                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
                {
                    doorEvents[0].Events[0] = true;
                    // GetComponent<DoorEvent>().Events[0] = true;
                }

                GameObject eventRaycaster = raycaster.RaycastFromCamera("LookEvent");
                if (eventRaycaster != null && eventRaycaster.gameObject.tag == "LookEvent")
                {
                    GetComponent<DoorEvent>().Events[1] = true;
                }

                if (doorEvents[0].Events[0] && doorEvents[0].Events[1])
                {
                    currentRoom++;
                }
                break;
            case 1:
                if (playerInventory.objectInHand != null)
                {
                    // GetComponent<DoorEvent>().Events[0] = true;
                    doorEvents[1].Events[0] = true;
                    currentRoom++;
                }
                break;
            case 2:
                if (true)
                {
                    //tahta hedef / hedef vurulacak
                    // GetComponent<DoorEvent>().Events[0] = true;
                    doorEvents[2].Events[0] = true;
                    currentRoom++;
                }
                break;
            case 3:
                if (true)
                {
                    //insan odası / insan vurulacak
                    // GetComponent<DoorEvent>().Events[0] = true;
                    doorEvents[3].Events[0] = true;
                    currentRoom++;
                }
                break;
            case 4:
                if (triggerFall.isFall)
                {
                    //bir çanın olduğu oda / insanların olduğu yere cisim düşüreceğiz
                    // GetComponent<DoorEvent>().Events[0] = true;
                    doorEvents[4].Events[0] = true;
                    currentRoom++;
                }
                break;
            case 5:
                if (playerInventory.objectInHand.GetComponent<Bomb>())
                {
                    //bomba odasına / masadan bombayı alıcaaz
                    // GetComponent<DoorEvent>().Events[0] = true;
                    doorEvents[5].Events[0] = true;
                    currentRoom++;
                }
                break;
            case 6:
                if (playerInventory.isPlaced)
                {
                    // insanların saklı olduğu oda / bombayı kurup sonraki odaya geçeceğiz
                    // GetComponent<DoorEvent>().Events[0] = true;
                    doorEvents[6].Events[0] = true;
                    currentRoom++;
                }
                break;
            case 7:
                if (bomb.isExplode)
                {
                    // korumalı oda / bomba patlayacak
                    // GetComponent<DoorEvent>().Events[0] = true;
                    doorEvents[7].Events[0] = true;
                    currentRoom++;
                }
                break;
        }
    }
}

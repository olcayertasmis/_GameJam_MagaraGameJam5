using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEventControl : MonoBehaviour
{
    [SerializeField] private int currentRoom;
    [SerializeField] private PlayerRaycaster raycaster;
    [SerializeField] private PlayerInventory playerInventory;

    void Update()
    {
        switch (currentRoom)
        {
            case 0:
                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
                {
                    GetComponent<DoorEvent>().Events[0] = true;
                }

                GameObject eventRaycaster = raycaster.RaycastFromCamera("LookEvent");
                if (eventRaycaster != null && eventRaycaster.gameObject.tag == "LookEvent")
                {
                    GetComponent<DoorEvent>().Events[1] = true;
                }
                break;
            case 1:
                if (playerInventory.objectInHand != null)
                {
                    GetComponent<DoorEvent>().Events[0] = true;
                }
                break;
            case 2:
                if (true)
                {
                    //tahta hedef / hedef vurulacak
                    GetComponent<DoorEvent>().Events[0] = true;
                }
                break;
            case 3:
                if (true)
                {
                    //insan odası / insan vurulacak
                    GetComponent<DoorEvent>().Events[0] = true;
                }
                break;
            case 4:
                if (true)
                {
                    //bir çanın olduğu oda / insanların olduğu yere cisim düşüreceğiz
                    GetComponent<DoorEvent>().Events[0] = true;
                }
                break;
            case 5:
                if (true)
                {
                    //bomba odasına / masadan bombayı alıcaaz
                    GetComponent<DoorEvent>().Events[0] = true;
                }
                break;
            case 6:
                if (true)
                {
                    // insanların saklı olduğu oda / bombayı kurup sonraki odaya geçeceğiz
                    GetComponent<DoorEvent>().Events[0] = true;
                }
                break;
            case 7:
                if (true)
                {
                    // korumalı oda / bomba patlayacak
                    GetComponent<DoorEvent>().Events[0] = true;
                }
                break;
        }
    }
}

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
    [SerializeField] private Target[] target;
    [SerializeField] private List<Target> inRoomTarget;
    [SerializeField] private List<AudioClip> roomSpeakingSound;
    AudioSource audioSource;
    private bool isAdded;

    private void TargetForControl()
    {
        for (int i = 0; i < target.Length; i++)
        {
            if (target[i].roomNumber == currentRoom)
            {
                inRoomTarget.Add(target[i]);
            }
        }
    }

    private void NextRoom()
    {
        inRoomTarget.Clear();
        isAdded = false;
        currentRoom++;
    }

    private void TargetForEachControl()
    {
        foreach (var item in inRoomTarget)
        {
            isAdded = true;
            if (item.isDead == false)
            {
                return;
            }
            else if (item.isDead == true && item == inRoomTarget[inRoomTarget.Count - 1])
            {
                doorEvents[currentRoom].Events[0] = true;
                NextRoom();
            }
        }
    }

    private void PlaySound()
    {
        audioSource.PlayOneShot(roomSpeakingSound[currentRoom]);
    }

    void Update()
    {
        switch (currentRoom)
        {
            case 0:
                PlaySound();
                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
                {
                    doorEvents[currentRoom].Events[0] = true;
                }

                GameObject eventRaycaster = raycaster.RaycastFromCamera("LookEvent");
                if (eventRaycaster != null && eventRaycaster.gameObject.tag == "LookEvent")
                {
                    doorEvents[currentRoom].Events[1] = true;
                }

                if (doorEvents[currentRoom].Events[0] && doorEvents[currentRoom].Events[1])
                {
                    NextRoom();
                }
                break;
            case 1:
                PlaySound();
                if (playerInventory.objectInHand != null)
                {
                    doorEvents[currentRoom].Events[0] = true;
                    NextRoom();
                }
                break;
            case 2:
                PlaySound();
                if (isAdded == false)
                {
                    TargetForControl();
                }
                TargetForEachControl();
                break;
            case 3:
                PlaySound();
                if (isAdded == false)
                {
                    TargetForControl();
                }
                TargetForEachControl();
                break;
            case 4:
                PlaySound();
                if (triggerFall.isFall)
                {
                    doorEvents[currentRoom].Events[0] = true;
                    NextRoom();
                }
                break;
            case 5:
                PlaySound();
                if (playerInventory.objectInHand.GetComponent<Bomb>())
                {
                    doorEvents[currentRoom].Events[0] = true;
                    NextRoom();
                }
                break;
            case 6:
                PlaySound();
                if (playerInventory.isPlaced)
                {
                    doorEvents[currentRoom].Events[0] = true;
                    NextRoom();
                }
                break;
            case 7:
                PlaySound();
                if (bomb.isExplode)
                {
                    doorEvents[currentRoom].Events[0] = true;
                    NextRoom();
                }
                break;
        }
    }
}

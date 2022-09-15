using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator anim;
    bool open;
    public bool close;

    private void Start()
    {
        anim = gameObject.transform.GetChild(0).GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!close)
            {
                DoorOpen();
                close = true;
            }
        }
    }

    public void DoorOpen()
    {
        open = !open;
        if (open)
        {
            anim.Play("OpenDoor", 0, 0.0f);
        }
        else
        {
            anim.Play("CloseDoor", 0, 0.0f);
        }
        print("press");
    }

}

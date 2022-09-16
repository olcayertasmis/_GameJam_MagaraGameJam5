using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator anim, anim2;
    AudioSource source;
    public AudioClip audioOpen, audioClose;
    bool open;
    public bool close;

    private void Start()
    {
        anim = gameObject.transform.GetChild(0).GetComponent<Animator>();
        anim2 = gameObject.transform.GetChild(1).GetComponent<Animator>();
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            DoorOpen();
        }
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
            anim2.Play("OpenDoor2", 0, 0.0f);
            source.PlayOneShot(audioOpen);
        }
        else
        {
            anim.Play("CloseDoor", 0, 0.0f);
            anim2.Play("CloseDoor2", 0, 0.0f);
            source.PlayOneShot(audioClose);
        }
    }

}

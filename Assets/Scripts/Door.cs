using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator anim;
    AudioSource source;
    public AudioClip audioOpen, audioClose;
    bool open;
    public bool close;

    private void Start()
    {
        anim = gameObject.transform.GetChild(0).GetComponent<Animator>();
        source = GetComponent<AudioSource>();
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
            source.PlayOneShot(audioOpen);
        }
        else
        {
            anim.Play("CloseDoor", 0, 0.0f);
            source.PlayOneShot(audioClose);
        }
        print("press");
    }

}

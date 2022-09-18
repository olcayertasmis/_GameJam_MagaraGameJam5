using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public Animator anim, anim2;
    AudioSource source;
    public AudioClip audioOpen, audioClose,final;
    bool open;
    public bool close;

    public bool isPlaying = false;

    float time = 2f;
    bool s;

    [SerializeField] private DoorEventControl doorEventControl;

    private void Start()
    {
        anim = gameObject.transform.GetChild(0).GetComponent<Animator>();
        anim2 = gameObject.transform.GetChild(1).GetComponent<Animator>();
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    DoorOpen();
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!close)
            {
                DoorOpen();
                close = true;
                doorEventControl.PlaySound();
            }
        }
    }

    public void DoorOpen()
    {

        if (isPlaying)
        {
            time -= Time.deltaTime;
        }
        if (isPlaying && time <= 0)
        {
            time = 10.1f;
            s = true;
            source.PlayOneShot(final);
        }
        if (isPlaying && time <= 0)
        {
            SceneManager.LoadScene("final");
        }
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

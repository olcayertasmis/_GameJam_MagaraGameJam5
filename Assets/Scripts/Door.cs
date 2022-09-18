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

    public GameObject bombloop;

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
        if (isPlaying)
        {
            time -= Time.deltaTime;
        }
        if (!s && time <= 0)
        {
            source.PlayOneShot(final);
            time = 10.1f;
            s = true;

        }
        if (s && time <= 0)
        {
            SceneManager.LoadScene("menu");
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
                doorEventControl.PlaySound();
                if (isPlaying)
                {
                    bombloop.SetActive(false);
                }
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

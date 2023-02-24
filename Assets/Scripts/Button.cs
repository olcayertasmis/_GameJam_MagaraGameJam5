using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Button : MonoBehaviour
{
    public PlayerRaycaster raycaster;
    [SerializeField] private TriggerFall triggerFall;
    bool b = false,s = false;
    float time = 0.9f;

    AudioSource source;

    public AudioClip clip, clip1;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            PushButton();
        }
        if (b)
        {
            time -= Time.deltaTime;
        }
        if (!s && time <= 0)
        {
            source.PlayOneShot(clip1);
            s = true;
        }
    }

    public void PushButton()
    {
        GameObject tempObject = raycaster.RaycastFromCamera("Button");

        if (tempObject != null && tempObject.tag == "Button" && !b)
        {
            triggerFall.UnfreezeRigidbody();
            source.PlayOneShot(clip);
            b = true;
        }
    }
}

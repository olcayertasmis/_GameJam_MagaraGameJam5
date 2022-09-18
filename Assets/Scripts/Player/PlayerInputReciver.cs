using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInputReciver : MonoBehaviour
{
    [SerializeField] public UnityEvent inputEvent;
    private float timer = 7f;
    [SerializeField] private PlayerInventory playerInventory;
    public Animator anim;
    bool d;
    AudioSource source;
    public AudioClip clip, clip2;
    public Door door;
    public GameObject bombloop;

    private void Start()
    {
        source = gameObject.transform.GetChild(1).GetComponent<AudioSource>();  
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            playerInventory.UseObjectInHand();
        }

        if (Input.GetKeyDown(KeyCode.E) && inputEvent != null)
        {

            inputEvent.Invoke();
        }

        if (Input.GetKey(KeyCode.F) && playerInventory.PlaceObjectControl())
        {
            Debug.Log(timer);
            timer -= Time.deltaTime;
            if (timer <= 5 && !d)
            {
                anim.Play("duvaryikilma", 0, 0.0f);
                d = true;
                source.PlayOneShot(clip2);
            }
            if (timer <= 0)
            {
                door.isPlaying = true;
                // inputEvent.Invoke();
                playerInventory.PlaceObject();
                source.PlayOneShot(clip);
                bombloop.SetActive(true);
                //return;
            }
        }
        else if (Input.GetKeyUp(KeyCode.F))
        {
            timer = 7f;
        }
    }
}

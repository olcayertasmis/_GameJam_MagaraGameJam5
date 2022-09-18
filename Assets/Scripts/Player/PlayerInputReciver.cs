using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInputReciver : MonoBehaviour
{
    [SerializeField] public UnityEvent inputEvent;
    private float timer = 10f;
    [SerializeField] private PlayerInventory playerInventory;
    public Animator anim;
    bool d;

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
            }
            if (timer <= 0)
            {
                // inputEvent.Invoke();
                playerInventory.PlaceObject();
                //return;
            }
        }
        else if (Input.GetKeyUp(KeyCode.F))
        {
            timer = 5f;
        }
    }
}

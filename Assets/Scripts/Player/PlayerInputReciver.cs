using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInputReciver : MonoBehaviour
{
    [SerializeField]
    public UnityEvent inputEvent;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)){

            inputEvent.Invoke();

        }
    }
}

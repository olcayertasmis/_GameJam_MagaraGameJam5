using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEvent : MonoBehaviour
{
    public bool[] Events;
    public Door door;
    public bool finish;

    void Update()
    {
        if (!finish)
        {
            for (int i = 0; i < Events.Length; i++)
            {
                if (Events[i] == false)
                {
                    return;
                }
                else if (Events[i] == true && i == Events.Length - 1)
                {
                    door.DoorOpen();
                    finish = true;

                }
            }
        }
    }
}

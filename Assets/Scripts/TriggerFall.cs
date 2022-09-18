using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TriggerFall : MonoBehaviour
{
    public bool isFall = false;

    private void Start()
    {

        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

    }
    public void UnfreezeRigidbody()
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        isFall = true;
    }
}

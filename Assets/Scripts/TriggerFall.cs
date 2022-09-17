using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TriggerFall : MonoBehaviour
{
    private void Start() {

        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    
    }
    public void UnfreezeRigidbody(){ //butona basildiginda bu metod calisacak / Corpyr

        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    
    }
}

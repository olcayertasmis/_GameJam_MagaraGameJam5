using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCollisionDetect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {

       if(other.tag == "Falling Object") _action();

    }

    private void _action(){
        
        Debug.Log("works"); //#TODO animasyonlar ve diger seyler eklenecek / Corpyr

    }
}

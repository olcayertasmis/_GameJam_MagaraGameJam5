using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycaster : MonoBehaviour
{
    public float rayRange;
    public Transform cameraGO;
    void LateUpdate()
    {
        
        _raycastFromCamera();

    }
    private void _raycastFromCamera(){

        RaycastHit hit;
        if (Physics.Raycast(cameraGO.position, cameraGO.TransformDirection(Vector3.forward), out hit, rayRange))
        {
            //bulursa event yaz / Corpyr
        }

    }
}

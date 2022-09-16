using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerRaycaster : MonoBehaviour
{
    [Header("Ray Attributes")]
    public float rayRange;
    public Transform startTransform;

    [Header("Events")]
    [SerializeField]
    public UnityEvent<GameObject> rayEvents;
    void LateUpdate()
    {

        _raycastFromCamera();

    }
    private void _raycastFromCamera()
    {

        RaycastHit hit;
        Debug.DrawRay(startTransform.position, startTransform.TransformDirection(Vector3.forward) * rayRange, Color.yellow);
        if (Physics.Raycast(startTransform.position, startTransform.TransformDirection(Vector3.forward), out hit, rayRange))
        {
            rayEvents?.Invoke(hit.transform.gameObject);
        }

    }

    public GameObject RaycastFromCamera()
    {

        RaycastHit hit;
        if (Physics.Raycast(startTransform.position, startTransform.TransformDirection(Vector3.forward), out hit, rayRange) && hit.transform.tag == "Pickupable") 
        {
            return hit.transform.gameObject;
        }

        if (Physics.Raycast(startTransform.position, startTransform.TransformDirection(Vector3.forward), out hit, rayRange) && hit.transform.tag == "Target")
        {
            return hit.transform.gameObject;
        }

        return null;
    }
}

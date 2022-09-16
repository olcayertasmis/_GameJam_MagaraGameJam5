using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerRaycaster : MonoBehaviour
{
    [Header("Ray Attributes")]
    [SerializeField] private float rayRange;
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
        if (Physics.Raycast(startTransform.position, startTransform.TransformDirection(Vector3.forward), out hit, rayRange) && hit.transform.tag == "Pickupable")
        {
            rayEvents?.Invoke(hit.transform.gameObject);
        }

    }

    public GameObject RaycastFromCamera(string objectTag)
    {

        RaycastHit hit;
        if (Physics.Raycast(startTransform.position, startTransform.TransformDirection(Vector3.forward), out hit, rayRange) && hit.transform.tag == objectTag)
        {
            return hit.transform.gameObject;
        }

        return null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyBuoyancy : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameObject objectToCopyFrom;
    [SerializeField] private GameObject objectToCopyTo;
    [SerializeField] private GameObject referencePosition;

    // Update is called once per frame
    void Update()
    {
        objectToCopyTo.transform.position = objectToCopyFrom.transform.position;
        objectToCopyTo.transform.rotation = objectToCopyFrom.transform.rotation;
        objectToCopyTo.transform.rotation *= referencePosition.transform.rotation;

        objectToCopyTo.transform.rotation *= Quaternion.Euler(playerController.lerpedAcceleration * -0.7f, 0f, playerController.lerpedAngularAcceleration * 0.15f);
    }
}

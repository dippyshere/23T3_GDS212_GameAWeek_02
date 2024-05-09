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
    private Vector3 lerpedPosition;

    // Update is called once per frame
    void Update()
    {
        // lerp the position when copying the position
        lerpedPosition = Vector3.Lerp(lerpedPosition, objectToCopyFrom.transform.position, Time.deltaTime * 6f);
        objectToCopyTo.transform.position = lerpedPosition;
        objectToCopyTo.transform.rotation = objectToCopyFrom.transform.rotation;
        objectToCopyTo.transform.rotation *= referencePosition.transform.rotation;

        objectToCopyTo.transform.rotation *= Quaternion.Euler(playerController.lerpedAcceleration * -0.7f, 0f, playerController.lerpedAngularAcceleration * 0.15f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float maxSpeed = 5f;
    [SerializeField] private float acceleration = 1f;

    [Header("Settings")]
    [SerializeField] private LayerMask hitLayers;

    [Header("References")]
    [SerializeField] private GameObject boatReferenceRotation;

    private Vector3 targetPosition;
    private Quaternion targetRotation;
    private Vector3 currentVelocity = Vector3.zero;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 999f, hitLayers))
            {
                // spawn a sphere at the hit point for debugging
                GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere.transform.position = hit.point;
                Debug.DrawLine(ray.origin, hit.point, Color.red, 1f);
                targetPosition = hit.point;
                targetRotation = Quaternion.LookRotation(hit.point - transform.position);
            }
        }

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, acceleration, maxSpeed);
        boatReferenceRotation.transform.rotation = Quaternion.Lerp(boatReferenceRotation.transform.rotation, targetRotation, Time.deltaTime * 2f);
    }
}

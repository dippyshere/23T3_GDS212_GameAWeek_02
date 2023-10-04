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
    [SerializeField] private GameObject markerObject;

    private Vector3 targetPosition;
    private Quaternion targetRotation;
    private Vector3 currentVelocity = Vector3.zero;
    private float currentSpeed = 0f;
    private float previousSpeed = 0f;
    private float currentAcceleration = 0f;
    private float lerpedAcceleration = 0f;
    private float markerOpacity = 0f;

    private void Update()
    {
        // movement input
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 999f, hitLayers))
            {
                // spawn a sphere at the hit point for debugging
                //GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                //sphere.transform.position = hit.point;
                Debug.DrawLine(ray.origin, hit.point, Color.red, 1f);
                targetPosition = hit.point;
                targetRotation = Quaternion.LookRotation(hit.point - transform.position);
            }
        }

        // movement
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, acceleration, maxSpeed);
        boatReferenceRotation.transform.rotation = Quaternion.Lerp(boatReferenceRotation.transform.rotation, targetRotation, Time.deltaTime * 2f);
        
        // marker location / opacity
        markerObject.transform.position = Vector3.Lerp(markerObject.transform.position, targetPosition, Time.deltaTime * 6f);
        markerOpacity = Mathf.Clamp01(Mathf.Lerp(markerOpacity, (1f - Mathf.Clamp(Vector3.Distance(transform.position, targetPosition), 4f, 7.5f) / 4f) * -1, Time.deltaTime * 6f));
        foreach (MeshRenderer meshRenderer in markerObject.GetComponentsInChildren<MeshRenderer>())
        {
            meshRenderer.material.color = new Color(meshRenderer.material.color.r, meshRenderer.material.color.g, meshRenderer.material.color.b, markerOpacity);
        }
        
        // boat angle with speed
        currentSpeed = currentVelocity.magnitude;
        // compute rate of change of speed
        currentAcceleration = (currentSpeed - previousSpeed) / Time.deltaTime;
        previousSpeed = currentSpeed;
        // lerp the acceleration to smooth it out
        lerpedAcceleration = Mathf.Lerp(lerpedAcceleration, currentAcceleration, Time.deltaTime * 6f);
        //boatReferenceRotation.transform.localRotation = Quaternion.Euler(lerpedAcceleration * -1f, boatReferenceRotation.transform.localRotation.y, boatReferenceRotation.transform.localRotation.z);
    }

    private void FixedUpdate()
    {
        // if the player is holding down the mouse button, raycast to the mouse position again
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 999f, hitLayers))
            {
                Debug.DrawLine(ray.origin, hit.point, Color.red, 1f);
                targetPosition = hit.point;
                targetRotation = Quaternion.LookRotation(hit.point - transform.position);
            }
        }
    }
}

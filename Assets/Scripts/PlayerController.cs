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
    public float markerOpacity = 0f;

    private void Update()
    {
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

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, acceleration, maxSpeed);
        boatReferenceRotation.transform.rotation = Quaternion.Lerp(boatReferenceRotation.transform.rotation, targetRotation, Time.deltaTime * 2f);
        
        markerObject.transform.position = Vector3.Lerp(markerObject.transform.position, targetPosition, Time.deltaTime * 6f);
        markerOpacity = Mathf.Clamp01(Mathf.Lerp(markerOpacity, (1f - Mathf.Clamp(Vector3.Distance(transform.position, targetPosition), 5f, 10f) / 5f) * -1, Time.deltaTime * 6f));
        foreach (MeshRenderer meshRenderer in markerObject.GetComponentsInChildren<MeshRenderer>())
        {
            meshRenderer.material.color = new Color(meshRenderer.material.color.r, meshRenderer.material.color.g, meshRenderer.material.color.b, markerOpacity);
        }
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

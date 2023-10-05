using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] public float maxSpeed = 5f;
    [SerializeField] private float acceleration = 1f;

    [Header("Settings")]
    [SerializeField] private LayerMask hitLayers;

    [Header("References")]
    [SerializeField] private GameObject boatReferenceRotation;
    [SerializeField] private GameObject markerObject;
    [SerializeField] private AudioSource waterSpraySource;
    [SerializeField] private GameObject hitTester;

    private Vector3 targetPosition;
    private Quaternion targetRotation;
    private Vector3 currentVelocity = Vector3.zero;
    public float currentSpeed = 0f;
    private float previousSpeed = 0f;
    private float currentAcceleration = 0f;
    public float lerpedAcceleration = 0f;
    private float previousRotationY = 0f;
    private float angularAccelerationY = 0f;
    public float lerpedAngularAcceleration = 0f;
    private float markerOpacity = 0f;

    private void Update()
    {
        // movement input
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 hitTesterScreenPosition = Camera.main.WorldToScreenPoint(hitTester.transform.position + hitTester.transform.forward * 470f);
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.y = Mathf.Clamp(mousePosition.y, 0, hitTesterScreenPosition.y);
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
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
        if (Vector3.Distance(transform.position, targetPosition) >= 0.3f)
        {
            targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
        }
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
        currentAcceleration = (currentSpeed - previousSpeed) / Time.deltaTime;
        previousSpeed = currentSpeed;
        lerpedAcceleration = Mathf.Lerp(lerpedAcceleration, currentAcceleration, Time.deltaTime * 6f);
        
        currentSpeed = currentVelocity.magnitude;
        currentAcceleration = (currentSpeed - previousSpeed) / Time.deltaTime;
        previousSpeed = currentSpeed;
        float currentRotationY = boatReferenceRotation.transform.rotation.eulerAngles.y;
        float rotationChangeY = currentRotationY - previousRotationY;
        rotationChangeY = Mathf.DeltaAngle(previousRotationY, currentRotationY);
        angularAccelerationY = rotationChangeY / Time.deltaTime;
        previousRotationY = currentRotationY;
        lerpedAngularAcceleration = Mathf.Lerp(lerpedAngularAcceleration, angularAccelerationY, Time.deltaTime * 6f);

        waterSpraySource.volume = Mathf.Clamp01(currentSpeed / 22f);
        waterSpraySource.pitch = Mathf.Clamp(0.6f + (currentSpeed / 5f), 0.6f, 1f);
    }

    private void FixedUpdate()
    {
        // if the player is holding down the mouse button, raycast to the mouse position again
        if (Input.GetMouseButton(0))
        {
            Vector3 hitTesterScreenPosition = Camera.main.WorldToScreenPoint(hitTester.transform.position + hitTester.transform.forward * 470f);
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.y = Mathf.Clamp(mousePosition.y, 0, hitTesterScreenPosition.y);
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 3000f, hitLayers))
            {
                Debug.DrawLine(ray.origin, hit.point, Color.red, 1f);
                targetPosition = hit.point;
                targetRotation = Quaternion.LookRotation(hit.point - transform.position);
            }
        }
    }
}

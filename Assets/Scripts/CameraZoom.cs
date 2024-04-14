using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Cinemachine;

public class CameraZoom : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] private float minZoom = 7f;
    [SerializeField] private float maxZoom = 20f;
    [SerializeField] private float zoomSpeed = 10f;

    [Header("References")]
    [SerializeField] private CinemachinePositionComposer cinemachinePositionComposer;

    private float currentZoom = 0f;
    private float targetZoom = 0f;

    // Start is called before the first frame update
    void Start()
    {
        currentZoom = targetZoom = cinemachinePositionComposer.CameraDistance;
    }

    // Update is called once per frame
    void Update()
    {
        // use the mouse wheel to zoom in and out
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        // lerping between the current zoom and the target zoom
        targetZoom -= scroll * zoomSpeed;
        targetZoom = Mathf.Clamp(targetZoom, minZoom, maxZoom);
        currentZoom = Mathf.Lerp(currentZoom, targetZoom, Time.deltaTime * 10f);
        cinemachinePositionComposer.CameraDistance = currentZoom;
    }
}

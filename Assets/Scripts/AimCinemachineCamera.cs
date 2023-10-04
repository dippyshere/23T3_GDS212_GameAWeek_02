using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class AimCinemachineCamera : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;
    private CinemachinePOV cinemachinePOV;
    private float multiplier = 1f;

    // Start is called before the first frame update
    void Start()
    {
        cinemachinePOV = cinemachineVirtualCamera.GetCinemachineComponent<CinemachinePOV>();
        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            multiplier = 0.5f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            cinemachinePOV.m_HorizontalAxis.m_InputAxisValue = Input.GetAxis("Mouse X") * multiplier;
            cinemachinePOV.m_VerticalAxis.m_InputAxisValue = Input.GetAxis("Mouse Y") * multiplier;
        }

        else
        {
            cinemachinePOV.m_HorizontalAxis.m_InputAxisValue = 0f;
            cinemachinePOV.m_VerticalAxis.m_InputAxisValue = 0f;
        }
    }
}

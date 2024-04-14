using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Cinemachine;

public class AimCinemachineCamera : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private CinemachineInputAxisController cinemachineInputAxisController;

    // Start is called before the first frame update
    void Start()
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            cinemachineInputAxisController.Controllers[0].Input.LegacyGain = 100f;
            cinemachineInputAxisController.Controllers[1].Input.LegacyGain = -100f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            cinemachineInputAxisController.Controllers[0].Input.LegacyInput = "Mouse X";
            cinemachineInputAxisController.Controllers[1].Input.LegacyInput = "Mouse Y";
        }

        else
        {
            cinemachineInputAxisController.Controllers[0].Input.LegacyInput = "";
            cinemachineInputAxisController.Controllers[1].Input.LegacyInput = "";
        }
    }
}

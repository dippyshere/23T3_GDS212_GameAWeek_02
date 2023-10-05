using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatAudioEngine : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private AudioSource[] engineSources;
    [SerializeField] private PlayerController playerController;

    // Update is called once per frame
    void Update()
    {
        float currentSpeed = playerController.currentSpeed;

        engineSources[0].pitch = Mathf.Lerp(0.87f, 1.3f, Mathf.InverseLerp(0f, 6f, currentSpeed));
        engineSources[0].volume = Mathf.Lerp(0.89f, 0.1f, Mathf.InverseLerp(0.7f, 7f, currentSpeed)) * 0.75f;
        engineSources[1].pitch = Mathf.Lerp(0.65f, 1.56f, Mathf.InverseLerp(0f, 18f, currentSpeed));
        if (currentSpeed < 11)
        {
            engineSources[1].volume = Mathf.Lerp(0.1f, 0.973f, Mathf.InverseLerp(0f, 11f, currentSpeed)) * 0.8f;
        }
        else
        {
            engineSources[1].volume = Mathf.Lerp(0.973f, 0.1f, Mathf.InverseLerp(11f, 18f, currentSpeed)) * 0.8f;
        }
        engineSources[2].pitch = Mathf.Lerp(0.823f, 1.2734f, Mathf.InverseLerp(10f, 30f, currentSpeed)) * 0.9f;
        engineSources[2].volume = Mathf.Lerp(0.1f, 1f, Mathf.InverseLerp(11f, 16f, currentSpeed));
    }
}
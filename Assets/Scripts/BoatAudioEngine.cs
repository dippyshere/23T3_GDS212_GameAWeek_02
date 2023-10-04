using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatAudioEngine : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float maxVolume = 1f;
    [SerializeField] private float minVolume = 0.1f;
    [SerializeField] private float minPitch = 0.7f;
    [SerializeField] private float maxPitch = 1.3f;

    [Header("References")]
    [SerializeField] private AudioSource[] engineSources;
    [SerializeField] private PlayerController playerController;

    // Update is called once per frame
    void Update()
    {
        float currentSpeed = playerController.currentSpeed;

        engineSources[0].pitch = Mathf.Lerp(minPitch, maxPitch, Mathf.InverseLerp(0f, 5f, currentSpeed));
        engineSources[0].volume = Mathf.Lerp(minVolume, maxVolume, Mathf.InverseLerp(7f, 1f, currentSpeed));
        engineSources[1].pitch = Mathf.Lerp(minPitch, maxPitch + 0.15f, Mathf.InverseLerp(1f, 15f, currentSpeed));
        engineSources[1].volume = Mathf.Lerp(minVolume, maxVolume, Mathf.InverseLerp(0f, 7f, currentSpeed));
        engineSources[2].pitch = Mathf.Lerp(minPitch + 0.15f, maxPitch - 0.15f, Mathf.InverseLerp(10f, 20f, currentSpeed));
        engineSources[2].volume = Mathf.Lerp(minVolume, maxVolume, Mathf.InverseLerp(9f, 16f, currentSpeed));
    }
}
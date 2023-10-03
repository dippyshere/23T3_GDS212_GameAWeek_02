using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyBuoyancy : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject objectToCopyFrom;
    [SerializeField] private GameObject objectToCopyTo;
    [SerializeField] private GameObject referencePosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        objectToCopyTo.transform.position = objectToCopyFrom.transform.position;
        objectToCopyTo.transform.rotation = objectToCopyFrom.transform.rotation;

        objectToCopyTo.transform.rotation *= referencePosition.transform.rotation;
    }
}

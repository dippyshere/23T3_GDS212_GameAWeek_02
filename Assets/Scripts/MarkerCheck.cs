using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerCheck : MonoBehaviour
{
    [SerializeField] private PlayerController controller;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("TargetBarrier"))
        {
            controller.StopBoat(collision, gameObject);
        }
    }
}

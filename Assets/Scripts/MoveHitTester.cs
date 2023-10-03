using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHitTester : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.position = new Vector3(Camera.main.transform.position.x, transform.position.y, Camera.main.transform.position.z);
    }
}

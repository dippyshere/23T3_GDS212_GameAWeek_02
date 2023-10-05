using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHitTester : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.position = new Vector3(Camera.main.transform.position.x, transform.position.y, Camera.main.transform.position.z);
        transform.position += transform.forward * 300f;
        transform.rotation = Quaternion.Euler(0f, Camera.main.transform.rotation.eulerAngles.y, 0f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishRotator : MonoBehaviour
{
    private float angle = 0f;
    private float speed;
    private Vector3 centrePoint;
    private float circleRadius;

    private void Start()
    {
        circleRadius = Random.Range(0.86f, 4.13f);
        speed = Random.Range(0.6f, 1.4f);
        centrePoint = transform.position;
    }

    void Update()
    {
        angle -= speed * Time.deltaTime;
        transform.position = new Vector3(centrePoint.x + Mathf.Cos(angle) * circleRadius, centrePoint.y, centrePoint.z + Mathf.Sin(angle) * circleRadius);
        transform.LookAt(centrePoint);
    }
}



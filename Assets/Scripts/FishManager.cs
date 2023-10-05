using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishManager : MonoBehaviour
{
    [SerializeField] private GameObject[] fishPrefabs;
    public int fishCount;


    // Start is called before the first frame update
    void Start()
    {
        if (fishCount == 0)
        {
            fishCount = Random.Range(2, 7);
        }
        for (int i = 0; i < fishCount; i++)
        {
            Instantiate(fishPrefabs[Random.Range(0, fishPrefabs.Length)], gameObject.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

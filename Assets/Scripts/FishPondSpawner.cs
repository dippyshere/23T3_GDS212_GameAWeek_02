using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishPondSpawner : MonoBehaviour
{
    [SerializeField] private GameObject fishPond;
    [SerializeField] private int numberToSpawn;
    [SerializeField] private int areaToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberToSpawn; i++)
        {
            Instantiate(fishPond, new Vector3(Random.Range(-areaToSpawn, areaToSpawn), 0, Random.Range(-areaToSpawn, areaToSpawn)), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

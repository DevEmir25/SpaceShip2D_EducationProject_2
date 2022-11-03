using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float Boundries;
    public GameObject MeteorSmall;
    public GameObject MeteorLarge;
    private int randomSpawn;

    private void Start()
    {
        InvokeRepeating("Spawn", 3, 2);
    }
    void Spawn()
    {
        Boundries = Random.Range(-4.48f, 4.48f);
        randomSpawn = Random.Range(0, 2);
        if (randomSpawn == 0)
        {
            Instantiate(MeteorSmall, new Vector3(5, Boundries, 0), transform.rotation);
        }
        if (randomSpawn == 1)
        {
            Instantiate(MeteorLarge, new Vector3(5, Boundries, 0), transform.rotation);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float Boundries;  // Sinir degiskeni yaziyoruz
    public GameObject MeteorSmall;
    public GameObject MeteorLarge;
    private int randomSpawn;  // Rastgele obje olusturacagimiz degiskeni yaziyoruz

    private void Start()
    {
        InvokeRepeating("Spawn", 3, 2);  //InvokeRepeating fonksiyonumuz ile belirlediðimiz degiskenlere gore sürekli olusacak nesneleri ayarliyoruz
    }
    void Spawn()
    {
        Boundries = Random.Range(-4.48f, 4.48f);  //Sinir degiskeninin hangi sinirlar arasinda olacagini belirtiyoruz
        randomSpawn = Random.Range(0, 2); // Bu kod ile hangi meteorun olusacagini rastgele belirtiyoruz
        if (randomSpawn == 0)  // Eger ilk meteorsa onu olustur
        {
            Instantiate(MeteorSmall, new Vector3(5, Boundries, 0), transform.rotation);
        }
        if (randomSpawn == 1) // Eger diger meteorsa onu olustur
        {
            Instantiate(MeteorLarge, new Vector3(5, Boundries, 0), transform.rotation);
        }
    }
}

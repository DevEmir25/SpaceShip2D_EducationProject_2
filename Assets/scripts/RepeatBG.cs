using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBG : MonoBehaviour
{
    public Vector3 StartPos;  
    private float speed = 1f;
    private void Start()
    {
        StartPos = transform.position; //Oyun basladiginda baslangic konumunu cekiyoruz
    }

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);  // Konumunu belirledigimiz degiskenlere gore hareket ettiriyoruz
        if(transform.position.x < -8.17f)  // Eger x pozisyonumuz -8 den kucukse
        {
            transform.position = StartPos;  // konumu tekrar baslangic konumuna getiriyoruz
        }
    }
}

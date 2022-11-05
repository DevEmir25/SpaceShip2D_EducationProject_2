using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int ScoreCount = 0;  //Score tutmak icin degisken yaziyoruz (bu islemi gameManager ile yapmamizin sebebi daha sonra yapacagimiz eklemeler
                               //sirasinda ulasmamiz gerekirse her yerden ulasabilelim diye. Dilersek kaydedip baska sahnelerde de erisebiliriz.)

    void Start()
    {
        instance = this; 
    }
}

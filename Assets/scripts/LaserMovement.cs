using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  // Text Mesh Pro icin kütüphane import ediyoruz

public class LaserMovement : MonoBehaviour
{
    public float laserSpeed;
    public static LaserMovement Instance;
    public GameObject explosion;

    TextMeshProUGUI Score;  // Score texti icin degisken yaziyoruz

    private void Awake()
    {
        Instance = this;
        Score = GameObject.Find("Score").GetComponent<TextMeshProUGUI>(); //Score objesini bulup o objenin textmeshpro componentini cekiyoruz
    }
    private void Update()
    {
        transform.Translate(Vector3.up * laserSpeed); // lazeri ileriye dogru gonderdigimiz kod (geminin rotate'ini 90 derece dondurdugumuz icin saga degil yukari yaziyoruz.)
        if(transform.position.x > 10)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)  // Collider ile etkilesime girdiginde olacaklari bu metota yazacagiz.
    {
        if (collision.gameObject.tag == "Meteor") // Eger lazerimizin collider 'ý ile etkilesime girerse
        {
            if (collision.gameObject.name == "MeteorBig(Clone)") GameManager.instance.ScoreCount++; // Eger buyuk meteoru patlattiysak skorumuza 1 ekliyoruz.
                                                                                                   // (Clone) -> oyun calisirken olusturulan meteorlarin isimine bakarak bulduk.
            else if (collision.gameObject.name == "MeteorSmall(Clone)") GameManager.instance.ScoreCount += 2; // Eger kucuk meteoru patlattiysak skorumuza 2 ekliyoruz.

            Score.text = "Score : " + GameManager.instance.ScoreCount.ToString(); // tuttugumuz score u gamemanager scriptinden cekip yazdiriyoruz
            Destroy(collision.gameObject); //laserimizi yok ediyoruz
            GameObject patlama = Instantiate(explosion, collision.transform.position, Quaternion.identity); // lazerin meteora degdigi noktada patlama efekti
                                                                                                           // iceren gameObject'i olusturup daha sonra uzerinde
                                                                                                          // islem yapabilmek icin bir degiskene atiyoruz
            Destroy(patlama,0.8f); // patlama efektini belirledigimiz gecikme suresi kadar sonra yok ediyoruz.
            Destroy(gameObject);  // lazerimizi yok ediyoruz.
        }
    }
}

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
        transform.Translate(Vector3.up * laserSpeed);
        if(transform.position.x > 5)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)  // Collider ile etkilesie girdiginde olacaklari bu metota yazicaz
    {
        if (collision.gameObject.tag == "Meteor") // Eger lazerimizin collider 'ý ile etkilesime girerse
        {
            GameManager.instance.ScoreCount++; //Score umuzu bir arttýrýyoruz
            Score.text = "Score : " + GameManager.instance.ScoreCount.ToString(); // tuttugumuz score u gamemanager scriptinden cekip yazdiriyoruz
            Destroy(collision.gameObject); //laserimizi yok ediyoruz
            GameObject mermi = Instantiate(explosion, collision.transform.position, Quaternion.identity);
            Destroy(mermi,0.8f);
            Destroy(gameObject);
            //particle,ses
        }
    }
}

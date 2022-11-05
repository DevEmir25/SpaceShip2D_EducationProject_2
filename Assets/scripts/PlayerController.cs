using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Butonlari kontrol edebilmek icin bu kutuphaneyi dahil ediyoruz.
using TMPro;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    float horizontalInput, verticalInput;
    public float speed;
    [SerializeField] GameObject[] Healths; // Birden fazla canimiz oldugu ve hepsine farkli zamanlarda ulasmak istedigimiz icin bu canlari birer
                                          // gameobject olarak tanimliyor ancak hepsini ayri ayri kodumuza dahil etmek yerine Healts isminde ve GameObject turunde bir
                                         // diziye atiyoruz.
    [SerializeField] GameObject laser; 
    [SerializeField] GameObject laserPoint; // Gemi hareket ettigi icin geminin ucunda olusturdugumuz objeyi dahil ediyoruz. (her seferinde konumunu hesaplamamak icin.)
    public Button RestartButton;
    public Button ReturnButton;
    private int healthCount;
    private void Awake()
    {
        RestartButton.gameObject.SetActive(false);
        ReturnButton.gameObject.SetActive(false);
        Instance = this;
        healthCount = 3;
    }
    private void OnCollisionEnter2D(Collision2D collision) // Karakterimiz ile baska bir objenin carpistigini kontrol eden metot.
    {
        if(collision.gameObject.tag == "Meteor") // eger carpisan obje meteor ise.
        {
            Healths[healthCount - 1].SetActive(false); // canlar dizisindeki son objeni (3. cani) kapatiyoruz.
            healthCount -= 1;
            Destroy(collision.gameObject); // "Carpisan" meteoru yok ediyoruz.
            if (healthCount == 0) // eger can 0'a dustuyse.
            {
                Time.timeScale = 0; // oyunun akisini durduruyoruz.
                RestartButton.gameObject.SetActive(true); 
                                                            // butonlarimizi aktif hale getiriyoruz
                ReturnButton.gameObject.SetActive(true);
            }
        }
    }
    
    void Update()
    {
        Move();
        Fire();
    }
    void Fire() // ates etme metotu.
    {
        if (Input.GetKeyDown(KeyCode.Space)) // space tusuna basiyorsak.
        {
            Instantiate(laser, laserPoint.transform.position, transform.rotation); // lazeri lazerPoint'in konumunda olusturan kod.
        }
    }
    void Move() // hareket kontrollerimiz.
    {
        horizontalInput = Input.GetAxis("Horizontal"); // yatay hareket
        verticalInput = Input.GetAxis("Vertical");    // dikey hareket
                                                     // Player objesinin rotation'unu 90 derece dondurdugumuzden dolayi dikey ve yatay
                                                    // inputlarimiz aslinda yer degistiriyorlar!!

        if (verticalInput > 0 && transform.position.y < 4.48f) // Oyunumuzun sinirlarini tanimlamak icin belirledigimiz
                                                              // bir deger araligi ile hareketimizi de sinirlandiriyoruz.
        {
                transform.Translate(Vector3.right * -speed);
        }
        if (verticalInput < 0 && transform.position.y > -4.48f)
        {
                transform.Translate(Vector3.right * speed);
        }
        if (horizontalInput > 0 && transform.position.x < 8.49f)
        {
                transform.Translate(Vector3.up * speed);
        }
        if (horizontalInput < 0 && transform.position.x > -8.49f)
        {
                transform.Translate(Vector3.up * -speed);
        }
    }
}

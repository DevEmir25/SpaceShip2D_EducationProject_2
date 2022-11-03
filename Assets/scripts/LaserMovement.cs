using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LaserMovement : MonoBehaviour
{
    public float laserSpeed;
    public static LaserMovement Instance;
    public GameObject explosion;

    TextMeshProUGUI Score;

    private void Awake()
    {
        Instance = this;
        Score = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        transform.Translate(Vector3.up * laserSpeed);
        if(transform.position.x > 5)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Meteor")
        {
            GameManager.instance.ScoreCount++;
            Score.text = "Score : " + GameManager.instance.ScoreCount.ToString(); 
            Destroy(collision.gameObject);
            GameObject mermi = Instantiate(explosion, collision.transform.position, Quaternion.identity);
            Destroy(mermi,0.8f);
            Destroy(gameObject);
            //particle,ses
        }
    }
}

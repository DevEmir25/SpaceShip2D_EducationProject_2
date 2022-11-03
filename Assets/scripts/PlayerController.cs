using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    float horizontalInput, verticalInput;
    public float speed;
    [SerializeField] GameObject[] Healths;
    [SerializeField] GameObject laser;
    [SerializeField] GameObject laserPoint;
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Meteor")
        {
            Healths[healthCount - 1].SetActive(false);
            healthCount -= 1;
            Destroy(collision.gameObject);
            if (healthCount == 0)
            {
                Time.timeScale = 0;
                RestartButton.gameObject.SetActive(true);
                ReturnButton.gameObject.SetActive(true);
            }
        }
    }
    
    void Update()
    {
        Move();
        Fire();
    }
    void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(laser, laserPoint.transform.position, transform.rotation);
            
        }
    }
    void Move()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        if (verticalInput > 0 && transform.position.y < 4.48f)
        {
                transform.Translate(Vector3.right * -speed);
        }
        if (verticalInput < 0 && transform.position.y > -4.48f)
        {
                transform.Translate(Vector3.right * speed);
        }
        if (horizontalInput > 0 && transform.position.x < 2.65f)
        {
                transform.Translate(Vector3.up * speed);
        }
        if (horizontalInput < 0 && transform.position.x > -2.65f)
        {
                transform.Translate(Vector3.up * -speed);
        }
    }
}

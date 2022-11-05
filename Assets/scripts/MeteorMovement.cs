using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorMovement : MonoBehaviour
{
    public static MeteorMovement Instance;
    private float speed = 1f;
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        if (transform.position.x < -10f) // Eger x pozisyonu -10 dan kucukse objei yoket
        {
            Destroy(gameObject);
        }
    }
}

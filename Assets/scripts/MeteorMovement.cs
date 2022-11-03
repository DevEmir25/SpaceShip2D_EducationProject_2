using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorMovement : MonoBehaviour
{
    public Vector3 StartPos;
    private float speed = 1f;

    private void Start()
    {
        StartPos = transform.position;
    }
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        if (transform.position.x < -5f)
        {
            Destroy(gameObject);
        }
    }
}

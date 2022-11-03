using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBG : MonoBehaviour
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
        if(transform.position.x < -8.17f)
        {
            transform.position = StartPos;
        }
    }
}

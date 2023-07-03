

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 4f;
    internal float moveSpeed;
    [SerializeField]
    private bool moveLeft;


    // Update is called once per frame
    void FixedUpdate()
    {
        if (moveLeft)
        {
            Vector3 temp = transform.position;
            temp.x -= speed * Time.deltaTime;
            transform.position = temp;
        }
        else
        {
            Vector3 temp = transform.position;
            temp.x += speed * Time.deltaTime;
            transform.position = temp;
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "bounce")
        {
            moveLeft = !moveLeft;
        }
    }
}
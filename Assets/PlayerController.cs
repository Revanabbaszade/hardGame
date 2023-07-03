using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D body;

    float horizontal;
    float vertical;

    public float runSpeed = 50.0f;
    internal float moveSpeed;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }

    void OnTriggerEnter2D(Collider2D target)
    {

        if (target.tag == "Enemy")
        {
            GameManager.instance.PlayerDied();
        }

        if (target.tag == "Goal")
        {
           GameManager.instance.PlayerReachedGoal();
        }

    }


} // class
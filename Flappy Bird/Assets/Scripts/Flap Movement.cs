using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float flap;
    private Rigidbody2D rb;
    private bool alive = true;



    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.IsGameStarted())
            return;

        if(rb.gravityScale == 0f)
        {
            rb.gravityScale = 1f;
        }
        Movement();
    }

    //Movement method
    private void Movement()
    {
        if (Input.GetKeyDown(KeyCode.Space) && alive) {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * flap, ForceMode2D.Impulse);
            //transform.position = new Vector2(transform.position.x, transform.position.y+1*speed*Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        alive = false;
        GameManager.Instance.PlayerDied();
        Debug.Log("Hit Object");
    }
}

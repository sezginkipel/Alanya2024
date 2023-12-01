using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D playerRb;
    public TMP_Text bananaText;
    
    public float speed = 250f;
    public float jumpForce = 200f;
    
    public bool isGrounded = true;
    
    public int bananas = 0;
    


    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Player Movement
        float horizontalInput = Input.GetAxis("Horizontal"); // -1 0 1 
        
        playerRb.velocity = new Vector2(horizontalInput * speed * Time.deltaTime, playerRb.velocity.y);
        

        // Player Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRb.velocity = Vector2.up * (jumpForce * Time.deltaTime);
            isGrounded = false;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.CompareTag("Banana"))
        {
            bananas++;
            bananaText.text = "Toplanan Muz: " + bananas;
            Destroy(trigger.gameObject);
        }
    }
}
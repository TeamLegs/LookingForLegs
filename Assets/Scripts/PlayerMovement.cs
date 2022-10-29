using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Delcare Variables
    [SerializeField] private float jumpSpeed = 5f; //Variable can be changed in the editor
    [SerializeField] private float speed = 5f;
    
    Rigidbody2D rb;

    public bool isGrounded = true;                         
    public float timeSinceAction = 0.0f;
    public float actionCooldown = 0.0f;

    // Awake is called when the script is being loaded
    public void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    public void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        timeSinceAction += Time.deltaTime;

        //If Space is pressed down, then the player will jump.
        if (Input.GetKeyDown(KeyCode.Space) && timeSinceAction > actionCooldown)
        {
            Jump();
        }

        //When a horizontal input is given then the player will move along the x axis. 
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += move * Time.deltaTime * speed;
    }

    public void Jump()
    {
        //If the object is grounded and the player presses space, then jump.
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == (true))
        {
            rb.AddForce(new Vector2(0f, jumpSpeed), ForceMode2D.Impulse);
        }
        
    }

    //If the object is colliding with the ground or obstacle, then set isGrounded to true
    public void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }

    //If the object is colliding with the ground or obstacle, then set isGrounded to false
    public void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}

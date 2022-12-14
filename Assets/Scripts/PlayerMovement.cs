using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Delcare Variables
    [SerializeField] private float jumpSpeed = 5f; //Variable can be changed in the editor
    [SerializeField] private float speed = 5f;

    [SerializeField] float speedMultiplier = 1;
    [SerializeField] float jumpMultiplier = 1;
    
    Rigidbody2D rb;
    private Animation anim;

    public bool isGrounded = true;                         
    public float timeSinceAction = 0.0f;
    public float actionCooldown = 0.0f;

    // Awake is called when the script is being loaded
    public void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animation>();
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
        transform.position += move * Time.deltaTime * speed * speedMultiplier;

        if (Input.GetAxis("Horizontal") < 0)
        {
            anim.shouldFlip(true);
        }
        else
        {
            anim.shouldFlip(false);
        }
    }

    public void Jump()
    {
        //If the object is grounded and the player presses space, then jump. if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0f, jumpSpeed * jumpMultiplier), ForceMode2D.Impulse);
            isGrounded = false;
        }
        
    }

    public bool isMoving()
    {
        return Input.GetAxis("Horizontal") != 0f;
    }

    //If the object is colliding with the ground or obstacle, then set isGrounded to true
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    //If the object is colliding with the ground or obstacle, then set isGrounded to false
    public void OnCollisionExit2D(Collision2D collision)
    {
    }

    public void setSpeedMultiplier(float multiplier)
    {
        speedMultiplier = multiplier;
    }

    public void setJumpMultiplier(float multiplier)
    {
        jumpMultiplier = multiplier;
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Delcare Variables
    [SerializeField] private float jumpSpeed = 5f; //Variable can be changed in the editor
    [SerializeField] private float speed = 5f;
    Rigidbody2D rb;

    // Awake is called when the script is being loaded
    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //If Space is pressed down, then the player will jump.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        //When a horizontal input is given then the player will move along the x axis. 
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += move * Time.deltaTime * speed;
    }

    void Jump()
    {
        rb.AddForce(new Vector2(0f, jumpSpeed), ForceMode2D.Impulse);
    }
}

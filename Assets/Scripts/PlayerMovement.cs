using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Delcare Variables
    public float jumpSpeed = 5f;
    public float speed = 8f;
    Rigidbody2D rb;
    GameObject character;

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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += move * Time.deltaTime * speed;
    }

    void Jump()
    {
        rb.AddForce(new Vector2(0f, jumpSpeed), ForceMode2D.Impulse);
    }
}

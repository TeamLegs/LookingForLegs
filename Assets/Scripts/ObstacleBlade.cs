using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBlade : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            GameObject player = col.gameObject;
            player.GetComponent<PlayerHealth>().TakeDamage(1);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorsoundcollide : MonoBehaviour
{
    AudioSource audioData;
    // Start is called before the first frame update
    void Start()
    {
        audioData = GetComponent<AudioSource>();
       // audioData.Play(0);
        Debug.Log("started");
    }

    // Update is called once per frame
    void Update()
    {
    }  
     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            audioData = GetComponent<AudioSource>();
        }
        audioData.Play(0);
            Debug.Log("Stop touching me");
    }
    
}

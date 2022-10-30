using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //Declare variables
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float xMin;
    [SerializeField] private float xMax;
    [SerializeField] private Transform backgroundImg;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Sets the current position of camera to the target and offsets its position.
        transform.position = target.position + offset;
        if(transform.position.x > xMax)
        {
            transform.position = new Vector3(xMax, transform.position.y, transform.position.z);
        }
        else if(transform.position.x < xMin)
        {
            transform.position = new Vector3(xMin, transform.position.y, transform.position.z);
        }
    }
}

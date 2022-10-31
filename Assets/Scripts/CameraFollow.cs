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
    
    [SerializeField] private float yUnlockAt;
    [SerializeField] private float yUnlockedOffset;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = target.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //Sets the current position of camera to the target and offsets its position.
        Vector3 newOffset = offset;
        if (player.transform.position.y >= yUnlockAt)
        {
            newOffset = new Vector3(offset.x,offset.y,offset.z);
            newOffset.y -= yUnlockedOffset;
        }
        transform.position = target.position + newOffset;
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

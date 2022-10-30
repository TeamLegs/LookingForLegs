using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //Declare variables
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform backgroundImg;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Sets the current position of camera to the target and offsets its position.
        var pos = target.position + offset;
        transform.position = pos;

        var bakPos = backgroundImg.transform.position;
        backgroundImg.SetPositionAndRotation(new Vector3(pos.x,bakPos.y, bakPos.z),backgroundImg.transform.rotation);
    }
}

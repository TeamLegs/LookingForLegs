using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerLegPickupLogic : MonoBehaviour
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
        GameObject legs = col.gameObject;
        if (legs.CompareTag("LegParent"))
        {
            legs.transform.parent = transform.GetChild(0);
            legs.transform.localPosition = Vector3.zero;
        }
    }
}

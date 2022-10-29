using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegValues : MonoBehaviour
{
    [SerializeField] private float speedMultiplier;
    [SerializeField] private float jumpMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    float getSpeedMultiplier()
    {
        return speedMultiplier;
    }

    float getJumpMultiplier()
    {
        return jumpMultiplier;
    }
}

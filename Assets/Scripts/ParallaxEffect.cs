using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ParallaxEffect : MonoBehaviour
{

    [SerializeField] private float parallaxEffect;
    [SerializeField] private Camera cam;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private bool lockInitialY = true;

    private float startX, length, startY;
    
    // Start is called before the first frame update
    void Start()
    {
        startX = transform.position.x;
        startY = transform.position.y;
        length = sprite.bounds.size.x * transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        float camX = cam.transform.position.x;
        
        float temp = camX * (1 - parallaxEffect);
        float dist = camX * parallaxEffect;

        var pos = transform.position;
        
        if (lockInitialY)
        {
            transform.position = new Vector3(startX + dist, startY, pos.z);
        }
        else
        {
            transform.position = new Vector3(startX + dist, pos.y, pos.z);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{

    [SerializeField] private float parallaxEffect;
    [SerializeField] private Camera cam;
    [SerializeField] private SpriteRenderer sprite;

    private float startX, length;
    
    // Start is called before the first frame update
    void Start()
    {
        startX = transform.position.x;
        length = sprite.bounds.size.x * transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        float camX = cam.transform.position.x;
        float temp = camX * (1 - parallaxEffect);
        float dist = camX * parallaxEffect;

        var pos = transform.position;
        transform.position = new Vector3(startX + dist, pos.y, pos.z);

        if (temp > startX + length/2)
        {
            startX += length;
        }
        else if (temp < startX - length/2)
        {
            startX -= length;
        }
    }
}

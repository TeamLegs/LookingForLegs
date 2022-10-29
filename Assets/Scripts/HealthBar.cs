using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private float time;
    private Vector3 startingPos;
    private bool shaking;
    ParticleSystem particles;
    // Start is called before the first frame update
    void Start()
    {
        shaking = false;
        particles = GetComponent<ParticleSystem>();
        particles.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        if (shaking)
        {
            time += Time.deltaTime;
           
            gameObject.transform.position += new Vector3(Random.RandomRange(-0.05f, 0.05f), Random.RandomRange(-0.05f, 0.05f), Random.RandomRange(-0.05f, 0.05f));
            if (time >= 0.2) {
                shaking = false;
                gameObject.transform.position = startingPos;
            }
        }

    }

    public void shake()
    {
        shaking = true;
        startingPos = gameObject.transform.position;
        particles.Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private float time;
    [SerializeField]private Vector3 startingPos;
    private bool shaking;
    ParticleSystem particles;
    [SerializeField] Sprite empty;
    // Start is called before the first frame update
    void Start()
    {
        startingPos = gameObject.transform.localPosition;
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
                gameObject.transform.localPosition = startingPos;
            }
        }

    }

    public void damage()
    {
        shaking = true;
        particles.Play();
        GetComponent<UnityEngine.UI.Image>().sprite = empty;
    }
}

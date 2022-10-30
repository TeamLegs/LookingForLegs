using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    //Declare variables
    public GameObject[] health;
    public int life;
    public bool dead;
    private float counter;
    [SerializeField] private float hitCooldown;

    public Animator anim;

    public LevelManager levelM;

    private float cooldown;

    private void Start()
    {
        life = health.Length;
        counter = 0;
        cooldown = hitCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (dead == true)
        {
            counter += Time.deltaTime;
            if(counter > 0.8)
            {
                anim.SetTrigger("Dead");
            }
        }

        if (cooldown >= 0)
        {
            cooldown -= Time.deltaTime;
        }
    }

    public void TakeDamage(int d)
    {
       
        if (life >= 1 && cooldown <= 0)
        {

            life -= d; // 1-1 = 0

            

            health[life].gameObject.GetComponent<HealthBar>().damage(); //[0]

            cooldown = hitCooldown;
            if (life < 1)
            {
                dead = true;
                GetComponent<ParticleSystem>().Play();
                GetComponent<SpriteRenderer>().enabled = false;
                transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
                Transform planePos = transform.GetChild(1).transform;
                Debug.Log(planePos);
                planePos.position = new Vector3(planePos.position.x, planePos.position.y - 0.8f, planePos.position.z);
            }
        }

        
    }

}

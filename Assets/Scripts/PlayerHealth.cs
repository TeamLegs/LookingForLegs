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

    public Animator anim;

    public LevelManager levelM;

    private void Start()
    {
        life = health.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (dead == true)
        {
            Debug.Log("Your dead.");
        }
    }

    public void TakeDamage(int d)
    {
       
        if (life >= 1)
        {

            life -= d; // 1-1 = 0

            

            health[life].gameObject.GetComponent<HealthBar>().damage(); //[0]

            if (life < 1)
            {
                dead = true;
                anim.SetTrigger("Dead");
            }
        }

        
    }

}

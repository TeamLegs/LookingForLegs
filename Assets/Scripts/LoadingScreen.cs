using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class LoadingScreen : MonoBehaviour
{
    //Declare Variables
    public Animator animator;

    private int levelToLoad;
    private float counter = 0;

    private bool waiting = false;

    void Start()
    {
        counter = 0;        
        waiting = true;
    }

    void FixedUpdate()
    {
        if (waiting)
        {
            counter += Time.deltaTime;

            if (counter > 3)
            {
                waiting = false;

                FadeToLevel(3);
            }

            Debug.Log(counter);
        }
    }

    public void MoveOnToLevel()
    {
        counter = 0;
        waiting = true;
    }

    public void FadeToLevel(int levelIndex)
    {

        levelToLoad = levelIndex;

        animator.SetTrigger("Start");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);

    }
}

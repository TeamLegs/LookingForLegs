using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    //Declare Variables
    public Animator anim;
    public Animator anim1;
    public FinishTrigger fT;

    private int levelToLoad;

    void Start()
    {
        levelToLoad = SceneManager.GetActiveScene().buildIndex + 1;
        Debug.Log(levelToLoad);
    }

    void Update()
    {

    }

    public void FadeToLevel()
    {
        levelToLoad = SceneManager.GetActiveScene().buildIndex + 1;
        Debug.Log(levelToLoad);
    }

    public void LevelFadeComplete()
    {        
        SceneManager.LoadScene(levelToLoad);
    }

    public void LevelFailed()
    {
        SceneManager.LoadScene(2);
    }
}

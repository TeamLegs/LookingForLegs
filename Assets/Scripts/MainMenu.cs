using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Declare Variables
    public Animator animator;

    private int levelToLoad;

    void Update()
    {
        
    }

    public void StartGame()
    {
        FadeToLevel(1);
    }

    public void EndGame()
    {
        Application.Quit();
        Debug.Log("You Quit. That was stupid.");
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

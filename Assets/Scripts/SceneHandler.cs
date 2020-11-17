
// SceneA.
// SceneA is given the sceneName which will
// load SceneB from the Build Settings


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public Animator animator;
    private int LevelToLoad;

    void Update() 
    {
        FadeToLevel(1);
    }

    void Start()
    {
        Debug.Log("LoadLevel1");
    }


    public void FadeToNextLevel()
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1); //calling this method will change the current scene

    }


    public void FadeToLevel(int levelIndex)
    {
        animator.SetTrigger("FadeOut");
        
        Debug.Log("LoadingScenenumber to load: " + levelIndex);
        //SceneManager.LoadScene(scenename);
    }
    public void OnFadeComplete()
    {
        SceneManager.LoadScene(LevelToLoad);
    }
}

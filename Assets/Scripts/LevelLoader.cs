using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;

    public void Transition()
    {
        LoadNextLevel();
    }
    
    public void LoadNextLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        else if (SceneManager.GetActiveScene().buildIndex == 1)
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex - 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loaderanimation : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    public void SampleScene ()
    {
        StartCoroutine(LoadLevel(0));
    }
    public void GameScene ()
    {
        StartCoroutine(LoadLevel(1));
    }
    public void about_page ()
    {
        StartCoroutine(LoadLevel(2));
    }
    
    public void player1page ()
    {
        StartCoroutine(LoadLevel(3));
    }
    public void player2page ()
    {
        StartCoroutine(LoadLevel(4));
    }

    IEnumerator LoadLevel(int LevelIndex)
    {
        transition.SetTrigger("start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(LevelIndex);
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public Animator transition2;
    public float transitionTime = 1.0f;


    // Update is called once per frame
    void Update()
    {
        
    }


    public void LoadNextLevel(string sceneName){
        StartCoroutine(LoadLevel(sceneName));


        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    IEnumerator LoadLevel(string sceneName){

        //Play animation
        transition.SetTrigger("Start");
        transition2.SetTrigger("Start");

        //Wait
        yield return new WaitForSeconds(transitionTime);

        //Load scene
        SceneManager.LoadScene(sceneName);

    }
}

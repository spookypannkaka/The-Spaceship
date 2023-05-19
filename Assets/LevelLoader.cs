using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public AudioFader audioFader;
    public float fadeDuration = 2f;
    public Animator transition;
    public Animator transition2;
    public float transitionTime = 1.0f;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (Input.GetKeyDown(KeyCode.Z)) {
            SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            ExitGame();
        }

    }


    public void LoadNextLevel(string sceneName){
        StartCoroutine(LoadLevel(sceneName));


        
    }


    IEnumerator LoadLevel(string sceneName){

        //Play animation
        transition.SetTrigger("Start");
        transition2.SetTrigger("Start");

        //Fade out music
        StartCoroutine(audioFader.FadeOut(fadeDuration));

        //Wait
        yield return new WaitForSeconds(transitionTime);

        //Load scene
        SceneManager.LoadScene(sceneName);

    }

    // Loads the start screen
    public void RestartGame() {
        SceneManager.LoadScene(0); // Replace with start screen build index
    }

    void ExitGame() {
        Application.Quit();
    }
}

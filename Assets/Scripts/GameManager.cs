using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    // Reloads the current scene
    public void ReplayLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Loads the start screen
    public void RestartGame() {
        SceneManager.LoadScene(1); // Replace with start screen build index
    }
}

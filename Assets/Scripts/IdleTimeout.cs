using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Idle timeout is the functionality that returns the game to the start screen if the user
// has not interacted with any key in a specified amount of time.
public class IdleTimeout : MonoBehaviour
{
    [SerializeField] Slider slider; // Remove later
    [SerializeField] float secondsUntilTimeout;
    float timeLeft;
    GameManager gameManager;

    void Awake() {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Start() {
        slider.maxValue = secondsUntilTimeout; // Remove later
        slider.value = slider.maxValue; // Remove later
        timeLeft = secondsUntilTimeout;
    }

    void Update() {
        DecreaseTime();

        if (Input.anyKey) { 
            ResetTime();
        }

        if (timeLeft <= 0) {
            OnTimeEnd();
        }
    }

    void DecreaseTime() {
        slider.value -= Time.deltaTime; // Remove later
        timeLeft -= Time.deltaTime;
    }

    void ResetTime() {
        slider.value = slider.maxValue; // Remove later
        timeLeft = secondsUntilTimeout;
    }

    void OnTimeEnd() {
        gameManager.RestartGame();
    }
}

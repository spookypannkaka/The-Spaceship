using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float totalTime = 20f;
    float currentTime;

    void Start() {
        currentTime = totalTime;
    }

    void Update() {
        currentTime -= Time.deltaTime;

        if (currentTime < 0) {
            // do something
            // maybe implement this if-statement in another class that uses a timer
        }
    }

    public float GetCurrentTime() {
        return currentTime;
    }
}
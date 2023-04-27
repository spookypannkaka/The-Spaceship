using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static int numberOfHits;
    public static int totalScore;

    // Start is called before the first frame update
    void Start()
    {
        numberOfHits = 0;
        totalScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
       // totalScore = numberOfHits + 5*Mathf.FloorToInt(Timer.timeRemaining);
    }

    void OnCollisionEnter2D(Collision2D other) {
        numberOfHits++;
    }
}

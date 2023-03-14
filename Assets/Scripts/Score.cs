using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static int numberOfHits;

    // Start is called before the first frame update
    void Start()
    {
        numberOfHits = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other) {
        numberOfHits++;
        
    }
}

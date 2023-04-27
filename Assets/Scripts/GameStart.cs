using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public GameObject player1Circle;
    public GameObject player2Circle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player1Circle.tag == player2Circle.tag && player1Circle.tag != "NoColor") {
            Debug.Log("trigger game start");
        }
    }
}

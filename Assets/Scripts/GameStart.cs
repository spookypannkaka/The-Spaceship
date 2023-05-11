using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public LevelLoader lvlLoader;

    public GameObject player1Circle;
    public GameObject player2Circle;
    public bool isStartTriggered;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (player1Circle.tag == player2Circle.tag && player1Circle.tag != "NoColor" && !isStartTriggered) {
            Debug.Log("trigger game start");
            lvlLoader.LoadNextLevel("LightSourcePrototype");
            isStartTriggered = true;
        }
    }
}
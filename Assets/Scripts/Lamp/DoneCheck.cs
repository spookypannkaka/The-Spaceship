using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoneCheck : MonoBehaviour
{

    public LevelLoader lvlLoader;

    // Start is called before the first frame update
    public bool playerOneDone = false; 
    public bool playerTwoDone = false; 
    void Start()
    {
        
    }

    public void playerIsDone(int player){
        if(player == 1){
            playerOneDone = true; 
        }
        if(player == 2){
            playerTwoDone = true; 
        }
    }

    public void checkIfBothDone(){
        if(playerOneDone && playerTwoDone){
            Debug.Log("ALL PLYER IS DONE");
            lvlLoader.LoadNextLevel("GrabWithCrane");
        }
    }

    // Update is called once per frame
    void Update()
    {
        checkIfBothDone();
    }
}

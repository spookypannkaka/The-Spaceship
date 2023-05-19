using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonsDisappearScript : MonoBehaviour
{
    Animator anim2;

    public GameObject player1Circle;
    public GameObject player2Circle;
    public bool isStartTriggered;

    // Start is called before the first frame update
    void Start()
    {
        anim2 = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player1Circle.tag == player2Circle.tag && player1Circle.tag != "NoColor" && !isStartTriggered){
            Debug.Log("trigger game start22222222");
            anim2.SetTrigger("makeButtonsDisappear");
        }
    }
}

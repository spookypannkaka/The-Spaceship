using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planetZoomScript : MonoBehaviour
{
    Animator anim2;

    public LevelLoader lvlLoader;

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
            Debug.Log("trigger game start33333");
            anim2.SetTrigger("makePlanetZoom");
            StartCoroutine(callLvlLoader());
        }
    }

    IEnumerator callLvlLoader()
    {    
        
        yield return new WaitForSeconds(5);

        lvlLoader.LoadNextLevel("LightSourcePrototype");
    }

}

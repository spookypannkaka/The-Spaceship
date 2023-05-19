using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesZooming : MonoBehaviour
{
    Animator anim2;

    public GameObject player1Circle;
    public GameObject player2Circle;
    public bool isStartTriggered;

    public GameObject particles;

    // Start is called before the first frame update
    void Start()
    {
        anim2 = particles.GetComponent<Animator>();
        //particles = GetComponent<GameObject>();
        particles.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(player1Circle.tag == player2Circle.tag && player1Circle.tag != "NoColor" && !isStartTriggered){
            Debug.Log("trigger game start4444");
            particles.SetActive(true);
            anim2.SetTrigger("makeParticlesMove");
        }
    }
}

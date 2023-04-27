using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLamp : MonoBehaviour
{

    public GameObject Lamp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Lamp.transform.position.x > 6.0f || Lamp.transform.position.x < -6.0f){
            Lamp.transform.position = new Vector3(-6.0f, 4.15f,0.0f);
            Debug.Log("hej");
        }
        else{
            Lamp.transform.position = new Vector3(Input.mousePosition.y/100, 4.15f, 0);
        }
        Debug.Log(Lamp.transform.position.x);


    }
}

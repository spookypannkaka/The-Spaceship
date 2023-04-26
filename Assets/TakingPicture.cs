using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakingPicture : MonoBehaviour
{

    public GameObject Planet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Planet.transform.position;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakingPicture : MonoBehaviour
{

    public GameObject Satelite;
    public GameObject centerPlanet;
    private Vector3 between;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = Satelite.transform.position;
        between = centerPlanet.transform.position - transform.position;
        between = Vector3.Normalize(between)/3.0f;
        transform.position += between;
        //transform.LookAt(centerPlanet.transform);
        //transform.rotation = Quaternion.LookRotation(between, Vector3.forward);
        Vector3 direction = centerPlanet.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
        transform.rotation *= Quaternion.Euler(0f, 0f, 180f);
    }
}

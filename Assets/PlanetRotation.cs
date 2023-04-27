using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class centerPlanetRotation : MonoBehaviour
{
    public float rotationSpeed = 2f;
    public GameObject Planet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Planet.transform.rotation *= Quaternion.Euler(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}

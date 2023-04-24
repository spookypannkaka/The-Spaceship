using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceChecker : MonoBehaviour
{
    public Transform playerObject; // Reference to the first game object
    public GameObject desiredOrbit; // Reference to the second game object
    public float successDistance = 0.06f;
    public Vector3 newOrbitPos = new Vector3(1.0f,1.0f,0.0f);


    //CustomAttributeScript customScript = desiredOrbit.GetComponent<CustomAttributeScript>();

    // void Start()
    // {
    //      CustomAttributeScript customScript = desiredOrbit.GetComponent<CustomAttributeScript>();
    //     if (customScript != null)
    //     {
    //         customScript.angle = 10;
    //     }
    // }
    void Update()
    {




        // Calculate the distance between the two objects
        float distance = Vector3.Distance(playerObject.position, desiredOrbit.Transform.Position);
        
        CustomAttributeScript customScript = desiredOrbit.GetComponent<CustomAttributeScript>();
        
        // Check if the distance is smaller than the successDistance
        if (distance < successDistance)
        {
            // Reposition the placeholder object to a new position
            //desiredOrbit.Transform.Position = newOrbitPos;
            customScript.angle = 10;
            Debug.Log("Success boi: " + distance);
        }
    }
}
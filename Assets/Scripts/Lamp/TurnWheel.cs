using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnWheel : MonoBehaviour
{
    [SerializeField] float wheelSensitivity = 100f;
    float rotationSpeed;

    // Update is called once per frame
    void Update()
    {
        rotationSpeed = wheelSensitivity * Time.deltaTime;

        if (Input.GetAxis("Mouse X") < 0) { // Mouse moves left
            transform.Rotate(0, 0, rotationSpeed);
        } else if(Input.GetAxis("Mouse X") > 0 ) { // Mouse moves right
            transform.Rotate(0, 0, -rotationSpeed);
        } else { // No movement

        }
    }
}

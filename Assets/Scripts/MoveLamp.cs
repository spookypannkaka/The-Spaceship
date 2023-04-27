using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLamp : MonoBehaviour
{
    [SerializeField] float moveSensitivity = 100f;
    float moveSpeed;

    void Update()
    {
        //transform.Translate(turnWheel.GetMoveSpeed(), 0, 0);
        moveSpeed = moveSensitivity * Time.deltaTime;

        if (Input.GetAxis("Mouse X") < 0) { // Mouse moves left
            transform.Translate(-moveSpeed, 0, 0);
        } else if(Input.GetAxis("Mouse X") > 0 ) { // Mouse moves right
            transform.Translate(moveSpeed, 0, 0);
        } else { // No movement

        }
    }
}

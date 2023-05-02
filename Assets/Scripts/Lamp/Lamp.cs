using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Lamp : MonoBehaviour
{
    [SerializeField] float moveSensitivity = 10f;
    [SerializeField] Vector3 outerRight = new Vector3(-6.0f,4.15f,0.0f);
    [SerializeField] Vector3 outerLeft = new Vector3(-6.0f,4.15f,0.0f);
    float moveSpeed;

    void Update()
    {
        //transform.Translate(turnWheel.GetMoveSpeed(), 0, 0);
        moveSpeed = moveSensitivity * Time.deltaTime;
       

        if (Input.GetAxis("Mouse X") < 0) { // Mouse moves left
            if(transform.position.x < outerLeft.x){
                transform.position = outerLeft; 
            }
            transform.Translate(-moveSpeed, 0, 0);
        } else if(Input.GetAxis("Mouse X") > 0 ) { // Mouse moves right
            if(transform.position.x > outerRight.x){
                transform.position = outerRight;
            }
            transform.Translate(moveSpeed, 0, 0);
        } else { // No movement

        }
    }
}

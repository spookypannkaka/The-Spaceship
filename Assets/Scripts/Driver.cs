using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 200.0f;
    [SerializeField] float moveSpeed = 15.0f;
    float steerAmount;
    float moveAmount;

    // Update is called once per frame
    void Update()
    {
        steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0,0,-steerAmount);
        transform.Translate(0,moveAmount,0);
    }
}

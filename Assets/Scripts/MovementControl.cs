using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControl : MonoBehaviour
{
    [Header("Controls")]
    [SerializeField] string upKey = "UpArrow";
    [SerializeField] string downKey = "DownArrow";
    [SerializeField] string leftKey = "LeftArrow";
    [SerializeField] string rightKey = "RightArrow";

    [Header("Settings")]
    [SerializeField] float movementSpeedX = 0.01f;
    [SerializeField] float movementSpeedY = 0.01f;

    KeyCode up;
    KeyCode down;
    KeyCode left;
    KeyCode right;

    void Awake()
    {
        up = (KeyCode)System.Enum.Parse(typeof(KeyCode), upKey);
        down = (KeyCode)System.Enum.Parse(typeof(KeyCode), downKey);
        left = (KeyCode)System.Enum.Parse(typeof(KeyCode), leftKey);
        right = (KeyCode)System.Enum.Parse(typeof(KeyCode), rightKey);
    }

    void Update()
    {
        if (Input.GetKey(up)) {
            transform.Translate(0,movementSpeedY,0);
        }

        if (Input.GetKey(down)) {
            transform.Translate(0,-movementSpeedY,0);
        }

        if (Input.GetKey(left)) {
            transform.Translate(-movementSpeedX,0,0);
        }

        if (Input.GetKey(right)) {
            transform.Translate(movementSpeedX,0,0);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRandomMovement : MonoBehaviour
{

    public float minSpeed = 0.02f; // The minimum number to randomize
    public float maxSpeed = 0.05f; // The maximum number to randomize
    public float minAngle = 0f;
    public float maxAngle = 3.14f;
    public float minDistance = 0.1f;
    public float maxDistance = 0.3f;
    public int counter = 0;

    private float backShift = 1;
    private float speed;
    private float angle;
    private float distance;
    private float currentDistance;
    private Vector3 lastPosition;
    bool runningAnimation = false;
    public GameObject Planet;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (runningAnimation){
            Planet.transform.position += new Vector3(Mathf.Cos(angle),Mathf.Sin(angle),0f)*speed*Time.deltaTime*backShift;
            currentDistance = Vector3.Distance(Planet.transform.position, lastPosition);
            if(currentDistance >= distance){
                counter+=1;
                backShift *= -1;
                if(counter == 2){
                    runningAnimation = false;
                    counter = 0;
                }
            }

        } else {
            lastPosition = Planet.transform.position;
            speed = Random.Range(minSpeed, maxSpeed);
            angle = Random.Range(minAngle, maxAngle);
            distance = Random.Range(minDistance, maxDistance);
            runningAnimation = true;
        }
    }
}

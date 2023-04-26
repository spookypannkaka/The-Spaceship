using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthMovement : MonoBehaviour
{
    public float sumOfMovement = 0f;
    public float moveAmount = 0.00001f;
    public float moveLimit = 0.5f;
    public int minusShift = 1;
    public GameObject Earth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sumOfMovement+=moveAmount;
        Earth.transform.position += new Vector3(moveAmount, moveAmount, 0.0f)*minusShift;
        if(sumOfMovement >= moveLimit){
            minusShift*=-1;
            sumOfMovement = 0;
        }
    }
}

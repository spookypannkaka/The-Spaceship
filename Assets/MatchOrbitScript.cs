using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchOrbitScript : MonoBehaviour
{

    public float velocity = 1f;
    public float orbitSpeed = 1f;
    public float orbitSize = 5f;
    public float angle;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

     angle += velocity * Time.deltaTime;

     Vector2 offset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * orbitSize;
     transform.position = offset;

    }
}

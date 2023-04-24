using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetOrbitController : MonoBehaviour
{

    public float velocity = 1f;

    public float orbitSpeed = 1f;
    public float orbitSize = 5f;
    public float mouseSensitivity = 4f;

    public float angle;

    public float minOrbitSize = 1f;
    public float maxOrbitSize = 5f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //float angle = Time.time * orbitSpeed;
    float orbitSize = Mathf.Abs(Input.mousePosition.x - Screen.width / 2) * mouseSensitivity / (Screen.width / 2);

        // if (Input.GetAxis("Mouse X") != 0) //thresholds
        // {
        //     orbitSize -= Input.GetAxis("Mouse X") * 0.1f;
        //     orbitSize = Mathf.Clamp(orbitSize, minOrbitSize, maxOrbitSize);
        // }

        angle += velocity * Time.deltaTime;

        //control size of orbit
        
        Vector2 offset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * orbitSize;
        transform.position = offset;

    //control velocity of the planet/object in orbit
        if (Input.GetKey(KeyCode.LeftArrow)) 
        {
            velocity -= 0.01f;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            velocity += 0.01f;
        }


    }
}

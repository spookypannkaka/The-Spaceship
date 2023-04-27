using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetOrbitController : MonoBehaviour
{

    [SerializeField] public float velocity = 1f;

    public float orbitSpeed = 1.0f;
    public float orbitSize = 5f;
    public float mouseSensitivity = 4f;

    public float angle;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float orbitSize = Mathf.Abs(Input.mousePosition.x - Screen.width / 2) * mouseSensitivity / (Screen.width / 2);

        angle += velocity * Time.deltaTime;

        //control size of orbit
        
        Vector2 offset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle))*orbitSize;
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

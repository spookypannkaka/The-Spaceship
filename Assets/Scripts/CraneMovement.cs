using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneMovement : MonoBehaviour
{

    [SerializeField] float moveAmount = 5.0f;

    public GameObject crane;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void grabItem()
    {
        Debug.Log("hej");


    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (crane.transform.position.x > -5.0f)
            {
                crane.transform.position += new Vector3(-5.0f, 0.0f, 0.0f);
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (crane.transform.position.x < 5.0f)
            {
                crane.transform.position += new Vector3(5.0f, 0.0f, 0.0f);

            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {



        }
        crane.transform.Translate(new Vector3(0, -0.5f, 0) * Time.deltaTime);
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneMovement : MonoBehaviour
{

    [SerializeField] float moveAmount;
    [SerializeField] float grabSpeed = 1.0f;

    private bool moveCrane = false; 
    private bool goingDown = false;
    private bool goingUp = false;

    public GameObject crane;
    public GameObject objectToGrab;


    // Start is called before the first frame update
    void Start()
    {

    }
    IEnumerator wait()
    {
       goingDown = false;
       RaycastHit2D hit = Physics2D.Raycast(crane.transform.position, -transform.up, 2.0f); 
       Debug.Log("Hit object tag: " + hit.collider.tag);
       if (hit.collider.gameObject.CompareTag("Item"))
           
                {
                    

                    objectToGrab = hit.collider.gameObject;
                    objectToGrab.transform.SetParent(crane.transform); // set the grabbed object's parent to the crane
                }
       yield return new WaitForSeconds(1);
       goingUp = true;  
        
    }

    public void grabItem()
    {
        if (goingUp)
        {
            moveAmount = grabSpeed * (Time.fixedDeltaTime/2);
            crane.transform.Translate(0, moveAmount, 0);
            if (crane.transform.position.y >= 2.0f)
            {
                goingUp = false;
                goingDown = false;
                moveCrane = false;
             
            }
        }
        else if(goingDown)
        {
            moveAmount = -grabSpeed * (Time.fixedDeltaTime/2);
            crane.transform.Translate(0, moveAmount, 0);
           
            if (crane.transform.position.y <= -1.3f)
            {
                 StartCoroutine(wait());      
            }
        }


    }

    // Update is called once per frame
    void Update()
    {
        
        Debug.DrawRay(crane.transform.position, -transform.up * 1.0f, Color.red);
        if (moveCrane)
        {
            grabItem();
        }

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
            goingDown = true; 
            moveCrane = true;
        }
    }
}


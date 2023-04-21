using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneMovement : MonoBehaviour
{

    [SerializeField] float moveAmount;
    [SerializeField] float grabSpeed = 1.0f;

    private bool inputFromPlayerOne = false; 
    private bool inputFromPlayerTwo = false; 

    private bool moveCrane = false;
    private bool goingDown = false;
    private bool goingUp = false;

     private bool craneHasItem = false;

    private bool moveCraneRight = false;
    private bool moveCraneLeft = false;
    private Vector3 cranePos;

    //Bools för att ainmera lägga saker på bordet och sen tillbaka till start
    private bool moveToTable = false; 
    private bool moveBackToStart = false;

    public GameObject crane;
    public GameObject crane2;

    private GameObject objectToGrab;

    private GameObject[] itemsOnBench = new GameObject[2];
    private int numberOfItemsOnBench = 0; 
    private Vector3 tablePosition1 = new Vector3(6.2f,-2.3f,0.0f);
    private Vector3 tablePosition2 = new Vector3(8.4f,-2.6f,0.0f);


    // Start is called before the first frame update
    void Start()
    {

    }

    IEnumerator goBackToOgPosition()
    {

        if(craneHasItem){
        itemsOnBench[numberOfItemsOnBench] = objectToGrab;
        numberOfItemsOnBench++;
        if(numberOfItemsOnBench == 1){
             objectToGrab.transform.position = tablePosition1;
       
        }
        else if(numberOfItemsOnBench == 2){
            objectToGrab.transform.position = tablePosition2;
        }
        objectToGrab.transform.parent = null;
        craneHasItem = false;
        }
        
        yield return new WaitForSeconds(1);
        Debug.Log(itemsOnBench[0]);
         moveBackToStart = true;

       
        
    }
    IEnumerator lookForItem(GameObject objectToCastRay)
    {
        goingDown = false;
        RaycastHit2D hit = Physics2D.Raycast(objectToCastRay.transform.position, -transform.up, 8.5f);
        
        if (hit.collider != null)
        {
            Debug.Log("Hit object tag: " + hit.collider.tag);
            objectToGrab = hit.collider.gameObject;
            objectToGrab.transform.SetParent(objectToCastRay.transform); // set the grabbed object's parent to the crane
            craneHasItem = true; 
        }
        yield return new WaitForSeconds(1);
        goingUp = true;

    }

    public void putItemOnTable(){
        moveAmount = grabSpeed * (Time.fixedDeltaTime / 3);
        if(moveBackToStart){
             crane.transform.Translate(-moveAmount, 0, 0);
            if(crane.transform.position.x <= -8){
                moveBackToStart = false;
                moveToTable = false;
            }
        }
        else{
            if(crane.transform.position.x >= 7.5){
            StartCoroutine(goBackToOgPosition());     
        }
        else {
            crane.transform.Translate(moveAmount, 0, 0);
        } 

        } 
               
        
        
    }

    public void grabItem(GameObject objectToMove)
    {
        if (goingUp)
        {
            moveAmount = grabSpeed * (Time.fixedDeltaTime / 3);
            objectToMove.transform.Translate(0, moveAmount, 0);
            if (objectToMove.transform.position.y >= 8.0f)
            {
                goingUp = false;
                goingDown = false;
                moveCrane = false;
                moveToTable = true; 

            }
        }
        else if (goingDown)
        {
            moveAmount = -grabSpeed * (Time.fixedDeltaTime / 3);
            objectToMove.transform.Translate(0, moveAmount, 0);

            if (objectToMove.transform.position.y <= 4.5)
            {
                StartCoroutine(lookForItem(objectToMove));
            }
        }


    }
    public void moveSide(string rightOrLeft, GameObject objectToMove){
        //shift movement right or left
        int shift = 1;
        if (rightOrLeft == "left"){
            shift = -1;
        }
        moveAmount = shift * grabSpeed * (Time.fixedDeltaTime / 3);
        objectToMove.transform.Translate(moveAmount, 0, 0);
    }

    
    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(crane2.transform.position,-transform.up*8.0f, Color.green);
        if(moveToTable){
            putItemOnTable();
        }

        if (moveCrane)
        {
            if(inputFromPlayerOne){
            grabItem(crane);

            }
            if(inputFromPlayerTwo){
            grabItem(crane2);

            }
        }

        if (moveCraneLeft){
            if(inputFromPlayerOne){
            moveSide("left", crane);
            float distance = Vector3.Distance(cranePos, crane.transform.position);
            if (distance >= 3){
                crane.transform.position += new Vector3(distance-3,0,0);
                moveCraneLeft = false;
                inputFromPlayerOne = false; 
            }
            }
            if(inputFromPlayerTwo){
                 moveSide("left", crane2);
            float distance = Vector3.Distance(cranePos, crane2.transform.position);
            if (distance >= 3){
                crane2.transform.position += new Vector3(distance-3,0,0);
                moveCraneLeft = false;
                inputFromPlayerTwo = false; 
            }
            }
           

        }
        if (moveCraneRight){
            
             if(inputFromPlayerOne){
            moveSide("right", crane);
            float distance = Vector3.Distance(cranePos, crane.transform.position);
            if (distance >= 3){
                crane.transform.position -= new Vector3(distance-3,0,0);
                moveCraneRight = false;
                inputFromPlayerOne = false; 
            }
            }
            if(inputFromPlayerTwo){
                 moveSide("right", crane2);
            float distance = Vector3.Distance(cranePos, crane2.transform.position);
            if (distance >= 3){
                crane2.transform.position -= new Vector3(distance-3,0,0);
                moveCraneRight = false;
                inputFromPlayerTwo = false; 
            }
            }

       
        }
         //SPELARE 1
        if (Input.GetKeyDown(KeyCode.A)){
            moveCraneLeft = true;
            inputFromPlayerOne = true;
            cranePos = crane.transform.position;

        }

        if (Input.GetKeyDown(KeyCode.D)){
            inputFromPlayerOne = true;
            moveCraneRight = true;
            cranePos = crane.transform.position;
            
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            inputFromPlayerOne = true;
            goingDown = true;
            moveCrane = true;
        }

        //SPELARE 2
        if (Input.GetKeyDown(KeyCode.LeftArrow)){
             moveCraneLeft = true;
            inputFromPlayerTwo = true;
            cranePos = crane2.transform.position;
           
        }

        if (Input.GetKeyDown(KeyCode.RightArrow)){
            inputFromPlayerTwo = true;
            moveCraneRight = true;
            cranePos = crane2.transform.position;
            
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            inputFromPlayerTwo = true;
            goingDown = true;
            moveCrane = true;
        }

        if(numberOfItemsOnBench == 2){
            if (itemsOnBench[0].tag == itemsOnBench[1].tag) {
            Debug.Log("pair!!!!!!");
        } else {
            Debug.Log("NOOOOOO");
        }

        }
    }
}


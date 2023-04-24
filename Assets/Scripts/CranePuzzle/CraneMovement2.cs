using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;

public class CraneMovement2 : MonoBehaviour
{
    
    [SerializeField] float grabSpeed = 1.0f;
    private float moveAmount;

    private bool ableToMove = true; 

     private bool moveCrane = false;
    private bool goingDown = false;
    private bool goingUp = false;

    private bool craneHasItem = false;
    
    private bool moveCraneRight = false;
    private bool moveCraneLeft = false;

    //Bools för att ainmera lägga saker på bordet och sen tillbaka till start
    private bool moveToTable = false; 
    private bool moveBackToStart = false;

    public GameObject crane;
    private Vector3 cranePos;

    private GameObject objectToGrab;

    public TableHandler table;
    
    // Start is called before the first frame update
    void Start()
    {
    
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

    IEnumerator goBackToOgPosition()
    {    
        //Mechanic för att få in object 
          moveBackToStart = true;
          goingDown = true;  
          table.addItemToTable(crane.transform.GetChild(0).gameObject);

           objectToGrab.transform.parent = null;
        yield return new WaitForSeconds(1);
        goingDown = false;
         
    }

    public void putItemOnTable(){ 
        if(moveBackToStart){
            //När den går ner och lägger den på bordet
            if(goingDown){

            }
            //Går tillbaka
            else{
                moveSide("right", crane);
                //Kranen är längst till vänster
                 if(crane.transform.position.x >= 22){
                    moveToTable = false;
                    moveBackToStart = false;
                    goingDown = false; 
                 }
            }
        }
        //Flyttar till bordet
        else{
            Debug.Log("Going left");
            moveSide("left", crane);
        //Den är över bordet
        if(crane.transform.position.x <= 7.5){
            StartCoroutine(goBackToOgPosition());     
        }
        }        
        
    }

    public void grabItem(GameObject objectToMove)
    {
        if (goingUp)
        {
            moveVertical("up", crane);
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
            //moveAmount = -grabSpeed * (Time.fixedDeltaTime / 3);
            //objectToMove.transform.Translate(0, moveAmount, 0);

            moveVertical("down", crane);
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

    public void moveVertical(string upOrDown, GameObject objectToMove){
        //shift movement right or left
        int shift = 1;
        if (upOrDown == "down"){
            shift = -1;
        }
        moveAmount = shift * grabSpeed * (Time.fixedDeltaTime / 3);
        objectToMove.transform.Translate(0, moveAmount, 0);
    }


    // Update is called once per frame
    void Update()
    {
         //Debug.DrawRay(crane2.transform.position,-transform.up*8.0f, Color.green);
        if(moveToTable){
            putItemOnTable();
        }

        if (moveCrane)
        {
            grabItem(crane);
        }

        if (moveCraneLeft){
            moveSide("left", crane);
            float distance = Vector3.Distance(cranePos, crane.transform.position);
            if (distance >= 3){
                crane.transform.position += new Vector3(distance-3,0,0);
                moveCraneLeft = false;
                ableToMove = true; 
            }
        }
        if (moveCraneRight){
            moveSide("right", crane);
            float distance = Vector3.Distance(cranePos, crane.transform.position);
            if (distance >= 3){
                crane.transform.position -= new Vector3(distance-3,0,0);
                moveCraneRight = false;
            }
        }

   
    //SPELARE 2
        if (Input.GetKeyDown(KeyCode.LeftArrow)){
            moveCraneLeft = true;
            cranePos = crane.transform.position;
           
        }

        if (Input.GetKeyDown(KeyCode.RightArrow)){
            moveCraneRight = true;
            cranePos = crane.transform.position;
            
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            goingDown = true;
            moveCrane = true;
        }
    
       

    
    }
}

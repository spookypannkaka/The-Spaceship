using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressInOrder : MonoBehaviour
{
    [SerializeField] int player; 


    [SerializeField] string[] correctOrder = new string[4];
    [SerializeField] GameObject[] colorIndicator = new GameObject[8];
    private int indicatorCounter = 0;  
    private string[] inputColors = new string[4];

    bool ableToMove = true;
    public DoneCheck checker; 

    // Start is called before the first frame update
   public void resetInput(){
    for(int i = 0; i < 4; i++){
        changeColor(Color.white,i);
    }
    indicatorCounter = 0;

   }

    public bool checkIfDone(){
        for(int i = 0; i < indicatorCounter; i++){
            if(inputColors[i] != correctOrder[i]) {                  
                return false;
            }
        }
        return true; 
    }

    public void changeColor(Color color, int number){
        Color newColor;
        if(color == Color.white){
            newColor = new Color(1.0f,1.0f,1.0f, 0.0f);
        }
        else{
            newColor = new Color(color.r,color.g,color.b, 1.0f);
        }
        
        var inputCircle = colorIndicator[number].GetComponent<SpriteRenderer>();
        var inputCircle2 = colorIndicator[number+4].GetComponent<SpriteRenderer>();
        inputCircle.color = newColor; 
        inputCircle2.color = newColor;
        indicatorCounter++; 
    }

    public void changeColorFeedBack(Color color){
        GameObject feedBackColor = null;
        GameObject feedBackColor1 = null;
        if(player == 1){
            feedBackColor = GameObject.Find("indicatorLight1.1");
            feedBackColor1 = GameObject.Find("indicatorLight2.1");
        }
        if(player == 2){
            feedBackColor = GameObject.Find("indicatorLight2.2");
            feedBackColor1 = GameObject.Find("indicatorLight1.2");
        }
        var feedColor = feedBackColor.GetComponent<SpriteRenderer>();
        var feedColor1 = feedBackColor1.GetComponent<SpriteRenderer>();
        feedColor.color = color;
        feedColor1.color = color;
    }

    public void onPressedButton(string color)
    {
        ableToMove=false;
        if (color == "Green")
        {    
            inputColors[indicatorCounter] = "Green";
            changeColor(Color.green,indicatorCounter);
            
        }
        if (color == "Red")
        {
            inputColors[indicatorCounter] = "Red";
            changeColor(Color.red,indicatorCounter);
            
        }
        if (color == "Yellow")
        {
            inputColors[indicatorCounter] = "Yellow"; 
            changeColor(Color.yellow,indicatorCounter); 
            

        }
        if (color == "Blue")
        {
            inputColors[indicatorCounter] = "Blue";
            changeColor(Color.blue,indicatorCounter);
            
        }

        ableToMove = true;
    }

IEnumerator ResetInput(){
        changeColorFeedBack(Color.red);
        yield return new WaitForSeconds(1);
        resetInput();
        Debug.Log("Reseted");
        changeColorFeedBack(Color.white);
         ableToMove = true; 
     }

    // Update is called once per frame
    void Update()
    {
       
        if(indicatorCounter == 4){
            ableToMove = false;
            if(checkIfDone()){
                changeColorFeedBack(Color.green);
                checker.playerIsDone(player);
            }
            else{
                StartCoroutine(ResetInput()); 
                  
            }
        }
        if(player == 1 && ableToMove){
            if (Input.GetKeyDown(KeyCode.E)) this.onPressedButton("Blue"); 
            if (Input.GetKeyDown(KeyCode.R)) this.onPressedButton("Yellow"); 
            if (Input.GetKeyDown(KeyCode.T)) this.onPressedButton("Red"); 
            if (Input.GetKeyDown(KeyCode.Y)) this.onPressedButton("Green");
        }
        else if(player == 2 && ableToMove){
            if (Input.GetKeyDown(KeyCode.H)) this.onPressedButton("Blue");
            if (Input.GetKeyDown(KeyCode.J)) this.onPressedButton("Yellow");
            if (Input.GetKeyDown(KeyCode.K)) this.onPressedButton("Red");
            if (Input.GetKeyDown(KeyCode.L)) this.onPressedButton("Green");
        }
        
    }
}
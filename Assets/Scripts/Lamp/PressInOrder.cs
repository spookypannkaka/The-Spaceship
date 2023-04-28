using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressInOrder : MonoBehaviour
{
    [SerializeField] int player; 


    [SerializeField] string[] correctOrder = new string[4];
    [SerializeField] GameObject[] colorIndicator = new GameObject[4];
    private int indicatorCounter = 0;  
    private string[] inputColors = new string[4];

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
        inputCircle.color = newColor; 
        indicatorCounter++; 
    }

    public void onPressedButton(string color)
    {
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
    }

    // Update is called once per frame
    void Update()
    {
       
        if(indicatorCounter == 4){
            if(checkIfDone()){
                Debug.Log("Correct!");
            }
            else{
                resetInput();
                Debug.Log("Reseted");
            }
        }
        if(player == 1){
            if (Input.GetKeyDown(KeyCode.E)) this.onPressedButton("Green");
            if (Input.GetKeyDown(KeyCode.R)) this.onPressedButton("Red");
            if (Input.GetKeyDown(KeyCode.T)) this.onPressedButton("Yellow");
            if (Input.GetKeyDown(KeyCode.Y)) this.onPressedButton("Blue");
        }
        else if(player == 2){
            if (Input.GetKeyDown(KeyCode.H)) this.onPressedButton("Green");
            if (Input.GetKeyDown(KeyCode.J)) this.onPressedButton("Red");
            if (Input.GetKeyDown(KeyCode.K)) this.onPressedButton("Yellow");
            if (Input.GetKeyDown(KeyCode.L)) this.onPressedButton("Blue");
        }
        
    }
}

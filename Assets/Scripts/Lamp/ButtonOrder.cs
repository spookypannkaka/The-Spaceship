using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOrder : MonoBehaviour
{

    public bool ResetOrderOnFailure = true;
    //Bool som avgör ifall spelaren kan trycka på sina knappar
    public bool AbleToPress = true;

    //En stack fylld med motsatt rätt ordning 
    private Stack<string> _buttonOrder = new Stack<string>();
    //Knapparna som skapas när man klickar på en knapp
    private Stack<GameObject> _objectList = new Stack<GameObject>();
     private Stack<GameObject> _objectList2 = new Stack<GameObject>();

    //För att kunna ändra objekt i scenen här i scripten
    public GameObject inputCircle;
    public GameObject indicatorLight;

    [SerializeField] Vector3 indicatorPos1 = new Vector3(0f,0f,0f);
    [SerializeField] Vector3 indicatorPos2 = new Vector3(0f,0f,0f);
    [SerializeField] Vector3 indicatorPos3 = new Vector3(0f,0f,0f);
    [SerializeField] Vector3 indicatorPos4 = new Vector3(0f,0f,0f);


    void Start()
    {
        this.ResetButtonOrder();
    }


    //För att kunna reseta stacken om man har gjort fel
    private void ResetButtonOrder()
    {
        _buttonOrder.Clear();
        //RÄTT Grön, Gul, Röd, Grön
       _buttonOrder.Push("Green");
        _buttonOrder.Push("Red");
        _buttonOrder.Push("Yellow");
        _buttonOrder.Push("Green");
    }

    //Tar bort alla inputCircles
    private void ResetObject()
    {
        int numberOfTry = _objectList.Count;
        for (int i = 0; i < numberOfTry; i++)
        {
            Destroy(_objectList.Peek());
            _objectList.Pop();
        }

    }

    public void createCircle(Color color, Vector3 pos, int player){
                GameObject inputCircles = Instantiate(inputCircle, pos, Quaternion.identity);
                
                var inputCircleRenderer = inputCircles.GetComponent<Renderer>();
                inputCircleRenderer.material.SetColor("_Color", color);
                if(player == 1){
                    _objectList.Push(inputCircles);
                }
                else if(player == 2){
                    _objectList2.Push(inputCircles);
                }
    }

    private void lightUp(Color color, int player){
                if(player == 1){
                    indicatorPos1.y =  -0.77f;
                    indicatorPos2.y =  -0.77f;
                    indicatorPos3.y =  -0.77f;
                    indicatorPos4.y =  -0.77f;


                    if(_objectList.Count == 0){
                    createCircle(color, indicatorPos1,player);
                    }
                    else if(_objectList.Count == 1){
                    createCircle(color, indicatorPos2,player);
                    }
                    else if(_objectList.Count == 2){
                    createCircle(color, indicatorPos3,player);
                    }
                    else if(_objectList.Count == 3){
                    createCircle(color, indicatorPos4,player);
                    }
                }
                if(player == 2){
                    indicatorPos1.y =  -1.4f;
                    indicatorPos2.y =  -1.4f;
                    indicatorPos3.y =  -1.4f;
                    indicatorPos4.y =  -1.4f;
                    if(_objectList2.Count == 0){
                    createCircle(color, indicatorPos1,player);
                    }
                    else if(_objectList2.Count == 1){
                    createCircle(color, indicatorPos2,player);
                    }
                    else if(_objectList2.Count == 2){
                    createCircle(color, indicatorPos3,player);
                    }
                    else if(_objectList2.Count == 3){
                    createCircle(color, indicatorPos4,player);
                    }
                }
                
    }

    public void onPressedButton(string token, int player)
    {
        if (AbleToPress)
        {
            //Alla dessa ifs kollar vilken knapp det är man tryckt och skapar en inputCircle med den färgen i baren
            if (token == "Green")
            {    
               lightUp(Color.green,player);
            }
            if (token == "Red")
            {
                lightUp(Color.red,player);

            }
            if (token == "Yellow")
            {
                lightUp(Color.yellow,player);

            }
            if (token == "Blue")
            {
                lightUp(Color.blue,player);

            }
            //Ifall färgen på knappen man tryckt i stämmer överräns med färgen högst i stacken 
            if(player == 1){
            if (_buttonOrder.Peek() == token)
            {
                _buttonOrder.Pop();
                if (_buttonOrder.Count == 0)
                {
                    //Klickat i rätt ordning
                    AbleToPress = false;
                    Debug.Log("RÄTT");

                    //Indicator blir grön
                    var lightRenderer = indicatorLight.GetComponent<Renderer>();
                    lightRenderer.material.SetColor("_Color", Color.green);
                }
                //Om det skulle vara att användaren slår in rätt input i slutet så blir det en bugg
                //T.EX Rätt svar: G R Y B och användaren slår i: R R B G så hade den inte hamnat i else utanför
                else if (_objectList.Count == 4)
                {
                    Debug.Log("Beugh");
                    //this.ResetButtonOrder();
                    //StartCoroutine(hold());
                }
            }
            else{
                //Annars så har man gjort 4 intryck och den börjar om från början
                if (this.ResetOrderOnFailure && _objectList.Count == 8)
                {
                    this.ResetButtonOrder();
                    StartCoroutine(hold());

                }
            }
                
            }
            
           
        }

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) this.onPressedButton("Green",1);
        if (Input.GetKeyDown(KeyCode.R)) this.onPressedButton("Red",1);
        if (Input.GetKeyDown(KeyCode.T)) this.onPressedButton("Yellow",1);
        if (Input.GetKeyDown(KeyCode.Y)) this.onPressedButton("Blue",1);

        if (Input.GetKeyDown(KeyCode.H)) this.onPressedButton("Green",2);
        if (Input.GetKeyDown(KeyCode.J)) this.onPressedButton("Red",2);
        if (Input.GetKeyDown(KeyCode.K)) this.onPressedButton("Yellow",2);
        if (Input.GetKeyDown(KeyCode.L)) this.onPressedButton("Blue",2);
    }

    //Detta är för att vänta 1 sekund innan den tar bort sin input samt att lampan lyser röd
    IEnumerator hold()
    {
        AbleToPress = false;

        var lightRenderer = indicatorLight.GetComponent<Renderer>();
        lightRenderer.material.SetColor("_Color", Color.red);

        yield return new WaitForSeconds(1);
        Debug.Log("Hold up!");
        this.ResetObject();
        lightRenderer.material.SetColor("_Color", Color.white);
        AbleToPress = true;
    }
}

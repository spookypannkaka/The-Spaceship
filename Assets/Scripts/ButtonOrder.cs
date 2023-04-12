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

    //För att kunna ändra objekt i scenen här i scripten
    public GameObject inputCircle;
    public GameObject indicatorLight;


    void Start()
    {
        this.ResetButtonOrder();
    }


    //För att kunna reseta stacken om man har gjort fel
    private void ResetButtonOrder()
    {
        _buttonOrder.Clear();
        _buttonOrder.Push("Blue");
        _buttonOrder.Push("Yellow");
        _buttonOrder.Push("Red");
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

    public void onPressedButton(string token)
    {
        if (AbleToPress)
        {
            //Alla dessa ifs kollar vilken knapp det är man tryckt och skapar en inputCircle med den färgen i baren
            if (token == "Green")
            {
                GameObject inputCircleG = Instantiate(inputCircle, new Vector3((7 + (2 * _objectList.Count)), -1.85f, 0), Quaternion.identity);
                _objectList.Push(inputCircleG);
                var inputCircleGRenderer = inputCircleG.GetComponent<Renderer>();
                inputCircleGRenderer.material.SetColor("_Color", Color.green);

            }
            if (token == "Red")
            {
                GameObject inputCircleR = Instantiate(inputCircle, new Vector3((7 + (2 * _objectList.Count)), -1.85f, 0), Quaternion.identity);
                _objectList.Push(inputCircleR);
                var inputCircleRRenderer = inputCircleR.GetComponent<Renderer>();
                inputCircleRRenderer.material.SetColor("_Color", Color.red);

            }
            if (token == "Yellow")
            {
                GameObject inputCircleY = Instantiate(inputCircle, new Vector3((7 + (2 * _objectList.Count)), -1.85f, 0), Quaternion.identity);
                _objectList.Push(inputCircleY);
                var inputCircleYRenderer = inputCircleY.GetComponent<Renderer>();
                inputCircleYRenderer.material.SetColor("_Color", Color.yellow);

            }
            if (token == "Blue")
            {
                GameObject inputCircleB = Instantiate(inputCircle, new Vector3((7 + (2 * _objectList.Count)), -1.85f, 0), Quaternion.identity);
                _objectList.Push(inputCircleB);
                var inputCircleBRenderer = inputCircleB.GetComponent<Renderer>();
                inputCircleBRenderer.material.SetColor("_Color", Color.blue);

            }
            //Ifall färgen på knappen man tryckt i stämmer överräns med färgen högst i stacken 
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
                    this.ResetButtonOrder();
                    StartCoroutine(hold());
                }
            }
            else
            {
                //Annars så har man gjort 4 intryck och den börjar om från början
                if (this.ResetOrderOnFailure && _objectList.Count == 4)
                {
                    this.ResetButtonOrder();
                    StartCoroutine(hold());

                }
            }
        }

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) this.onPressedButton("Green");
        if (Input.GetKeyDown(KeyCode.S)) this.onPressedButton("Red");
        if (Input.GetKeyDown(KeyCode.D)) this.onPressedButton("Yellow");
        if (Input.GetKeyDown(KeyCode.F)) this.onPressedButton("Blue");
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

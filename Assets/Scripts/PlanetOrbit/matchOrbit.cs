using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class matchOrbit : MonoBehaviour
{

    public LevelLoader lvlLoader;

    public GameObject Goal;
    public GameObject Satelite;
    public GameObject Flash;
    List<Color> colorList;
    List<GameObject> objectColorList;
    public GameObject Color1;
    public GameObject Color2;
    public GameObject Color3;
    public GameObject Color4;

    SpriteRenderer spriteRenderer;
    SpriteRenderer outline;
    List<SpriteRenderer> spriteColorList;
    SpriteRenderer spriteColor1;
    SpriteRenderer spriteColor2;
    SpriteRenderer spriteColor3;
    SpriteRenderer spriteColor4;

    public Sprite greenOutline;
    public Sprite redOutline;

    public float mouseSensitivity = 1.2f;
    public float successDistance = 0.5f;
    public float maxVelocity = 2.0f;
    public float minRadius = 4.0f;

    public float gameStateTimer = 0;
    public float timerLimit = 2f;
    public int wins = 0;
    public int winsToWin = 3;
    public List<float> GoalVelocities;
    public List<float> GoalRadius;
    public List<float> GoalAngles;

    public float velocitySatelite = 1f;
    public float radiusSatelite = 1f;
    public float angleSatelite = 1f;

    public float velocityGoal;
    public float radiusGoal;
    public float angleGoal;

    public bool runningAnimation = false;
    private bool pushedButton = false;
    private bool beenInCircle = false;
    private bool failed = false;
    private int preCircleIndex = 10;
    private int hitCounter = 0;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Screen.width);
        Debug.Log(Screen.height);

        outline = Goal.GetComponent<SpriteRenderer>();

        spriteRenderer = Flash.GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;

        spriteColor1 = Color1.GetComponent<SpriteRenderer>();
        spriteColor2 = Color2.GetComponent<SpriteRenderer>();
        spriteColor3 = Color3.GetComponent<SpriteRenderer>();
        spriteColor4 = Color4.GetComponent<SpriteRenderer>();

        GoalVelocities = new List<float>(){0.8f, 1.0f, -1.2f};
        GoalRadius = new List<float>(){3.0f, 4.0f, 4.2f};
        GoalAngles = new List<float>(){8.0f, 3.0f, 6.0f};

        velocityGoal = GoalVelocities[0];
        radiusGoal = GoalRadius[0];
        angleGoal = GoalAngles[0];

        colorList = new List<Color>();
        colorList.Add(Color.red);
        colorList.Add(Color.green);
        colorList.Add(Color.blue);
        colorList.Add(Color.yellow);
        spriteColorList = new List<SpriteRenderer>();
        spriteColorList.Add(spriteColor1);
        spriteColorList.Add(spriteColor2);
        spriteColorList.Add(spriteColor3);
        spriteColorList.Add(spriteColor4);
        objectColorList = new List<GameObject>();
        objectColorList.Add(Color1);
        objectColorList.Add(Color2);
        objectColorList.Add(Color3);
        objectColorList.Add(Color4);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(Goal.transform.position,Satelite.transform.position);
        if (distance < successDistance){

            if (!runningAnimation){

                //Add color or sign that you are doing somehting right!!
                outline.sprite = greenOutline;

                //Add to the timer
                gameStateTimer += Time.deltaTime;

                //If you have been close enough for sertain time
                if (gameStateTimer >= timerLimit){

                    //Now it is time to take photo of the planet and play guitar hero.
                    runningAnimation = true;

                    //Snap the planet to the goal
                    angleSatelite = angleGoal;
                    velocitySatelite = velocityGoal;
                    radiusSatelite = radiusGoal;

                    //Enable colored circles and position them!
                    float angleInc = 0.4f*3.14f; //Position the colors 90 degrees away from satelite (planet in this code...)
                    float angleForColor = angleSatelite + angleInc;
                    for (int i = 0; i < 4; i++)
                    {
                        Vector2 position = new Vector2(Mathf.Sin(angleForColor), Mathf.Cos(angleForColor)) * radiusSatelite;
                        objectColorList[i].transform.position = position;
                        angleForColor += angleInc;

                        spriteColorList[i].material.color = colorList[i];
                        spriteColorList[i].enabled = true;
                    }

                    //reset timer
                    gameStateTimer = 0;

                }

            } 
                

        } else { //They are outside of the successrange
            gameStateTimer = 0;
            outline.sprite = redOutline;
        }


        //Moving satelite and goal
        angleSatelite += velocitySatelite * Time.deltaTime;
        angleGoal += velocityGoal * Time.deltaTime;


        if (runningAnimation){

            //flash effect!
            if (spriteRenderer.enabled){
                spriteRenderer.enabled = false;
            } else {
                spriteRenderer.enabled = true;
            }

            //Check if they are close enough to a color and check if the press the right key
            float shortestDistance = 10000f;
            int currentIndex = 10;
            for (int i = 0; i < 4; i++)
            {
                float distanceToColor = Vector3.Distance(objectColorList[i].transform.position, Satelite.transform.position);
                if (distanceToColor < shortestDistance)
                {
                    shortestDistance = distanceToColor;
                    currentIndex = i;

                }
            }
            //This let us reset variables ONLY ONCE every time a new circle is the closest one
            if (preCircleIndex != currentIndex)
            {
                preCircleIndex = currentIndex;
                beenInCircle = false;
                pushedButton = false;
            }

            if (shortestDistance < successDistance)
            {
                beenInCircle = true;
                //Did they press a?
                if (Input.GetKey(KeyCode.A))
                {
                    spriteColorList[currentIndex].enabled = false;
                    if(!pushedButton)
                    {
                        hitCounter++;
                        pushedButton = true;//pushed button
                        Debug.Log(hitCounter);
                    }
                    
                } else if (Input.anyKeyDown && !Input.GetKey(KeyCode.A)) //Did they press any other key?
                {
                    Debug.Log("Fel! tryck tangenten a");
                    runningAnimation = false;
                    failed = true;
                }

            } else
            {
                if (beenInCircle && !pushedButton)
                {
                    Debug.Log("DU MISSA HAHAHAHAH!");
                    runningAnimation = false;
                    failed = true;
                }
            }

            //Turn off animation, enable controls, hide colors
            //Vill vi låta dem snurra ett varv även om de missar en färg?
            if (hitCounter == 4 || (!runningAnimation)){

                hitCounter = 0; //reset counter for how many they hit
                preCircleIndex = 10; //This also need a reset

                //Disable rendering for all colors
                spriteRenderer.enabled = false;
                for (int i = 0; i < 4; i++)
                {
                    spriteColorList[i].enabled = false;
                }

                //add a point if they didnt fail
                if (!failed)
                {
                    wins += 1;

                }
                failed = false;

                //Check if they won!
                if (wins == winsToWin)
                {
                    Debug.Log("DONE!");
                    lvlLoader.LoadNextLevel("EndScene"); //Load next scene
                }

                //Progress mission
                angleGoal = GoalAngles[wins];
                velocityGoal = GoalVelocities[wins];
                radiusGoal = GoalRadius[wins];

                //Back to matching orbits
                runningAnimation = false; 
            }


        }

        if (!runningAnimation){

            
            // Update the mouse position if it goes of screen
            //Debug.Log(Input.mousePosition.x);
            Vector3 mousePosition = Input.mousePosition;
            if (mousePosition.x > 1920)
            {
                UnityEngine.InputSystem.Mouse.current.WarpCursorPosition(new Vector2(Screen.width, mousePosition.y));
            } else if (mousePosition.x < 0)
            {
                UnityEngine.InputSystem.Mouse.current.WarpCursorPosition(new Vector2(0, mousePosition.y));
            }

            radiusSatelite = minRadius + Input.mousePosition.x*mouseSensitivity*1.2f/Screen.width;
            //Debug.Log(radiusSatelite);
            
            //Calculate and limit new radius and velocities
            if (radiusSatelite < minRadius){
                radiusSatelite = minRadius;
            }

            velocitySatelite = (Input.mousePosition.y - Screen.height / 2) * mouseSensitivity / (Screen.height / 2);
            if(velocitySatelite > maxVelocity){
                velocitySatelite = maxVelocity;
            }
            if(velocitySatelite < -maxVelocity){
                velocitySatelite = -maxVelocity;
            }
        }


        //Update position of Goal
        Vector2 offsetGoal = new Vector2(Mathf.Sin(angleGoal), Mathf.Cos(angleGoal))*radiusGoal;
        Goal.transform.position = offsetGoal;

        //control size of satelite
        
        Vector2 offset = new Vector2(Mathf.Sin(angleSatelite), Mathf.Cos(angleSatelite))*radiusSatelite;
        Satelite.transform.position = offset;


    }
}

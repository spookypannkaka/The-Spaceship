using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class matchOrbit : MonoBehaviour
{

    public LevelLoader lvlLoader;

    public GameObject Goal;
    public GameObject Planet;
    public GameObject Flash;
    //////////////////////////////////////////////
    List<Color> colorList;
    List<GameObject> objectColorList;
    public GameObject Color1;
    public GameObject Color2;
    public GameObject Color3;
    public GameObject Color4;

    SpriteRenderer spriteRenderer;
    SpriteRenderer outline;
    /// ////////////////////////////////////////////
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

    public float velocityPlanet = 1f;
    public float radiusPlanet = 1f;
    public float anglePlanet = 1f;

    public float velocityGoal;
    public float radiusGoal;
    public float angleGoal;
    public float angleCheck;

    public bool runningAnimation = false;
    private bool pushedButton = false;
    private bool beenInCircle = false;
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
        ///////////////////////////////////////////////////
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
        float distance = Vector3.Distance(Goal.transform.position,Planet.transform.position);
        if (distance < successDistance){

            if (!runningAnimation){

                //Add color or sign that you are doing somehting right!!
                outline.sprite = greenOutline;

                //Add to the timer
                gameStateTimer += Time.deltaTime;

                //If you have been close enough for sertain time
                if (gameStateTimer >= timerLimit){
                    
                    //Add a win
                    wins+=1;


                    //Now it is time to take photo of the planet and play guitar hero.
                    runningAnimation = true;

                    //Snap the planet to the goal
                    anglePlanet = angleGoal;
                    angleCheck = anglePlanet;
                    velocityPlanet = velocityGoal;
                    radiusPlanet = radiusGoal;

                    ////////////////////////////////////////////////////
                    //Enable colored circles and position them!
                    float angleInc = 0.4f*3.14f; //Position the colors 90 degrees away from satelite (planet in this code...)
                    float angleForColor = anglePlanet + angleInc;
                    for (int i = 0; i < 4; i++)
                    {
                        Vector2 position = new Vector2(Mathf.Sin(angleForColor), Mathf.Cos(angleForColor)) * radiusPlanet;
                        objectColorList[i].transform.position = position;
                        angleForColor += angleInc;

                        spriteColorList[i].material.color = colorList[i];
                        spriteColorList[i].enabled = true;
                    }

                    //reset timer
                    gameStateTimer = 0;

                    if (wins == winsToWin){
                        Debug.Log("DONE!");
                        lvlLoader.LoadNextLevel("EndScene");
                    }

                }

            } 
                

        } else {
            gameStateTimer = 0;
            outline.sprite = redOutline;
        }


        //Moving
        anglePlanet += velocityPlanet * Time.deltaTime;
        angleGoal += velocityGoal * Time.deltaTime;


        if (runningAnimation){

            //flash effect!
            if (spriteRenderer.enabled){
                spriteRenderer.enabled = false;
            } else {
                spriteRenderer.enabled = true;
            }

            ///////////////////////////////////////////////
            //Check if they are close enough to a color and also check if the press the right key
            float shortestDistance = 10000f;
            int currentIndex = 10;
            for (int i = 0; i < 4; i++)
            {
                float distanceToColor = Vector3.Distance(objectColorList[i].transform.position, Planet.transform.position);
                if (distanceToColor < shortestDistance)
                {
                    shortestDistance = distanceToColor;
                    currentIndex = i;

                }
            }
            if (preCircleIndex != currentIndex)
            {
                preCircleIndex = currentIndex;
                beenInCircle = false;
                pushedButton = false;
            }

            if (shortestDistance < successDistance)
            {
                beenInCircle = true;
                if (Input.GetKey(KeyCode.A))
                {
                    spriteColorList[currentIndex].enabled = false;
                    if(!pushedButton)
                    {
                        hitCounter++;
                        pushedButton = true;//pushed button
                        Debug.Log(hitCounter);
                    }
                    
                }

            } else
            {
                if (beenInCircle && !pushedButton)
                {
                    preCircleIndex = 10; //reset
                    runningAnimation = false;
                }
            }

            //Turn off animation, enable controls, hide colors
            //Vill vi låta dem snurra ett varv även om de missar en färg? (angleCheck + (2 * 3.14f) <= angleGoal) 
            if (hitCounter == 4 || (!runningAnimation)){
                hitCounter = 0;
                angleGoal = GoalAngles[wins];
                velocityGoal = GoalVelocities[wins];
                radiusGoal = GoalRadius[wins];
                runningAnimation = false;
                spriteRenderer.enabled = false;
                for (int i = 0; i < 4; i++)
                {
                    spriteColorList[i].enabled = false;
                }
            }


        }

        if (!runningAnimation){
            
            radiusPlanet = minRadius + Input.mousePosition.x*mouseSensitivity*1.2f/Screen.width;
            //Debug.Log(radiusPlanet);
            
            if (radiusPlanet < minRadius){
                radiusPlanet = minRadius;
            }

            velocityPlanet = (Input.mousePosition.y - Screen.height / 2) * mouseSensitivity / (Screen.height / 2);


            if(velocityPlanet > maxVelocity){
                velocityPlanet = maxVelocity;
            }
            if(velocityPlanet < -maxVelocity){
                velocityPlanet = -maxVelocity;
            }
        }


        //Update position of Goal
        Vector2 offsetGoal = new Vector2(Mathf.Sin(angleGoal), Mathf.Cos(angleGoal))*radiusGoal;
        Goal.transform.position = offsetGoal;

        //control size of orbit
        
        Vector2 offset = new Vector2(Mathf.Sin(anglePlanet), Mathf.Cos(anglePlanet))*radiusPlanet;
        Planet.transform.position = offset;


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class matchOrbit : MonoBehaviour
{
    public GameObject Goal;
    public GameObject Planet;
    public GameObject Flash;
    SpriteRenderer spriteRenderer;
    SpriteRenderer outline;
    public Sprite greenOutline;
    public Sprite redOutline;

    public float mouseSensitivity = 4.0f;
    public float successDistance = 0.5f;
    public float maxVelocity = 2.0f;
    public float minRadius = 4.0f;

    public float gameStateTimer = 0;
    public float timerLimit = 2f;
    public int wins = 0;
    public List<float> GoalVelocities;
    public List<float> GoalRadius;
    public List<float> GoalAngles;

    public float velocityPlanet = 1f;
    public float radiusPlanet = 1f;
    public float anglePlanet = 1f;

    public float velocityGoal;
    public float radiusGoal;
    public float angleGoal;

    public bool runningAnimation = false;
    public float angleCheck;

    // Start is called before the first frame update
    void Start()
    {

        outline = Goal.GetComponent<SpriteRenderer>();

        spriteRenderer = Flash.GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;

        GoalVelocities = new List<float>(){0.8f, 1.0f, 1.2f};
        GoalRadius = new List<float>(){3.0f, 4.0f, 6.0f};
        GoalAngles = new List<float>(){8.0f, 3.0f, 6.0f};

        velocityGoal = GoalVelocities[0];
        radiusGoal = GoalRadius[0];
        angleGoal = GoalAngles[0];    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(Goal.transform.position,Planet.transform.position);
        if ((distance < successDistance)){

            if (!runningAnimation){

                //Add color or sign that you are doing somehting right!!
                outline.sprite = greenOutline;

                //Add to the timer
                gameStateTimer += Time.deltaTime;

                //If you have been close enough for sertain time
                if (gameStateTimer >= timerLimit){
                    wins+=1;


                    //Now it is time to take photo of the planet:
                    runningAnimation = true;

                    //Snap the planet to the goal
                    anglePlanet = angleGoal;
                    angleCheck = anglePlanet;
                    velocityPlanet = velocityGoal;
                    radiusPlanet = radiusGoal;

                    gameStateTimer = 0;

                    if (wins == 3){
                        Debug.Log("DONE!");
                    }

                }

            } 
                

        } else {
            gameStateTimer = 0;
            outline.sprite = redOutline;
        }

        anglePlanet += velocityPlanet * Time.deltaTime;
        angleGoal += velocityGoal * Time.deltaTime;


        if (runningAnimation){
                //Runs after animation and enables controls again

                if(spriteRenderer.enabled){
                    spriteRenderer.enabled = false;
                } else {
                    spriteRenderer.enabled = true;
                }

                if (angleCheck+(2*3.14f) <= angleGoal){
                    angleGoal = GoalAngles[wins];
                    velocityGoal = GoalVelocities[wins];
                    radiusGoal = GoalRadius[wins];
                    runningAnimation = false;
                    spriteRenderer.enabled = false;
                }

        }

        if (!runningAnimation){
            
            radiusPlanet = Mathf.Abs(Input.mousePosition.x - Screen.width / 2) * mouseSensitivity / (Screen.width / 2);
            if (radiusPlanet < minRadius){
                radiusPlanet = minRadius;
            }
            //control velocity of the planet/object in orbit
            if (Input.GetKey(KeyCode.LeftArrow)) 
            {
                velocityPlanet -= 0.01f;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                velocityPlanet += 0.01f;
            }

            if(velocityPlanet > maxVelocity){
                velocityPlanet = maxVelocity;
            }
            if(velocityPlanet < 0){
                velocityPlanet = 0;
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

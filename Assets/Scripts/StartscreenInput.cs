using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartscreenInput : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    [SerializeField] string player1Or2;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player1Or2 == "1") {
            if (Input.GetKey(KeyCode.E)) { // Blue button
                spriteRenderer.color = new Color32(0,0,255,255);
                transform.gameObject.tag = "Color1";
            } else if (Input.GetKey(KeyCode.R)) { // Yellow button
                spriteRenderer.color = new Color32(255,255,0,255);
                transform.gameObject.tag = "Color2";
            } else if (Input.GetKey(KeyCode.T)) { // Red button
                spriteRenderer.color = new Color32(255,0,0,255);
                transform.gameObject.tag = "Color3";
            } else if (Input.GetKey(KeyCode.Y)) { // Green button
                spriteRenderer.color = new Color32(0,255,0,255);
                transform.gameObject.tag = "Color4";
            } else {
                spriteRenderer.color = new Color32(0,0,0,255);
                transform.gameObject.tag = "NoColor";
            }
        }

        if (player1Or2 == "2") {
            if (Input.GetKey(KeyCode.H)) { // Blue button
                spriteRenderer.color = new Color32(0,0,255,255);
                transform.gameObject.tag = "Color1";
            } else if (Input.GetKey(KeyCode.J)) { // Yellow
                spriteRenderer.color = new Color32(255,255,0,255);
                transform.gameObject.tag = "Color2";
            } else if (Input.GetKey(KeyCode.K)) { // Red button
                spriteRenderer.color = new Color32(255,0,0,255);
                transform.gameObject.tag = "Color3";
            } else if (Input.GetKey(KeyCode.L)) { // Green button
                spriteRenderer.color = new Color32(0,255,0,255);
                transform.gameObject.tag = "Color4";
            } else {
                spriteRenderer.color = new Color32(0,0,0,255);
                transform.gameObject.tag = "NoColor";
            }
        }
    }
}

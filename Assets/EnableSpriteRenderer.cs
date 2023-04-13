using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableSpriteRenderer : MonoBehaviour
{
    public Transform Square;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        Square = GameObject.Find("Square").transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position.x - Square.position.x) < 20)
        {
            spriteRenderer.enabled = true;
        }

    }
}

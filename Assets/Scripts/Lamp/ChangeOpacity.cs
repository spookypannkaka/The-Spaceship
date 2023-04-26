using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeOpacity : MonoBehaviour
{

    public Renderer blackBoxRenderer;
    public Transform triangleTransform;

    public GameObject triangle;

    public GameObject Box;

    public Material OpacityRectMaterial;

    public Texture alphaTexture;
    public float opacity = 0.5f;
    private Material blackBoxMaterial;

    // Start is called before the first frame update
    void Start()
    {
        blackBoxMaterial = Box.GetComponent<Renderer>().material;


        //GameObject OpacityRect = GameObject.Find("Black screen");
        //OpacityRectMaterial = OpacityRect.GetComponent<Renderer>().material;
//
//
        //Debug.Log(OpacityRect);
    }

    // Update is called once per frame
    void Update()
    {


        // Calculate the bounds of the triangle
        SpriteRenderer spriteRenderer = triangle.GetComponent<SpriteRenderer>();
        Bounds bounds = spriteRenderer.bounds;
        float minX = bounds.min.x;
        float maxX = bounds.max.x;

        Vector3 blackBoxPosition = Box.transform.position;
        float x = (blackBoxPosition.x - minX) / (maxX - minX);
        float y = blackBoxPosition.y;

        // Get the alpha value from the alpha texture at the position of the black box
        Texture2D alphaTexture2D = (Texture2D)alphaTexture;
        float alpha = alphaTexture2D.GetPixelBilinear(x, y).r;

        // Set the opacity of the black box material to the calculated alpha value
        Color color = blackBoxMaterial.color;
        color.a = opacity * alpha;
        blackBoxMaterial.color = color;


        //if(Input.GetKeyDown(KeyCode.G)){
        //    Color color = OpacityRectMaterial.color;
        //    color.a = 0.5f;
        //    OpacityRectMaterial.color = color;
        //}
    }
}

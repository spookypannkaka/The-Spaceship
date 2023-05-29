using UnityEngine;
using System.Collections;

public class ActivateScreens : MonoBehaviour
{
    void Start ()
    {
        //Activate all connected screens
        for (int i = 1; i < Display.displays.Length; i++)
            {
                Display.displays[i].Activate();
            }
        //Hide the mouse :)
        Cursor.visible = false;
    }
    
    void Update()
    {

    }
}
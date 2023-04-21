using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableChecker : MonoBehaviour
{
    GameObject[] objectsOnTable = new GameObject[2];
    Collider2D tableBounds;
    //public GameObject playerOneObject;
    //public GameObject playerTwoObject;

    // Start is called before the first frame update
    void Start()
    {
        objectsOnTable[0] = GameObject.Find("Circle"); // Right now you need to manually change the name of the items here to compare them. Random name -> array slot empty
        objectsOnTable[1] = GameObject.Find("Capsule");
    }

    // Update is called once per frame
    void Update()
    {
        if (objectsOnTable[0] == null || objectsOnTable[1] == null) {
            Debug.Log("not enough items");
        } else {
            CompareItems();
        }
    }

    void CompareItems() {
        if (objectsOnTable[0].tag == objectsOnTable[1].tag) {
            Debug.Log("pair!!!!!!");
        } else {
            Debug.Log("NOOOOOO");
        }
    }
}
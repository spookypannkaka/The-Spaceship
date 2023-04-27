using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableHandler : MonoBehaviour
{
    private GameObject[] itemsOnBench = new GameObject[2];
    private int numberOfItemsOnBench = 0; 
    private Vector3 tablePosition1 = new Vector3(6.2f,-2.3f,0.0f);
    private Vector3 tablePosition2 = new Vector3(8.4f,-2.6f,0.0f);

    private Vector3 originalPos1;
    private Vector3 originalPos2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void addItemToTable(GameObject item, Vector3 OgPosition){
        itemsOnBench[numberOfItemsOnBench] = item;
        numberOfItemsOnBench++;
        if(numberOfItemsOnBench == 1){
             item.transform.position = tablePosition1;
             originalPos1 = OgPosition;
       
        }
        else if(numberOfItemsOnBench == 2){
            item.transform.position = tablePosition2;
            originalPos2 = OgPosition; 
        }
    }

    public void resetTable(){
        itemsOnBench[0].transform.position = originalPos1;
         itemsOnBench[1].transform.position = originalPos2;
          numberOfItemsOnBench = 0;
    }

    public void clearTable(){
            numberOfItemsOnBench = 0;
            Destroy(itemsOnBench[0]);
            Destroy(itemsOnBench[1]);
            itemsOnBench[0] = null;
            itemsOnBench[1] = null;

    }

    public void moveToStand(){
        if(itemsOnBench[0].tag == "HelmCloth"){
            GameObject helm = GameObject.Find("helmetPrefab");
            GameObject helm1 = Instantiate(helm);
            GameObject helm2 = Instantiate(helm);
            helm1.transform.position = new Vector3(2.65f,0.7f,0.0f);
            helm2.transform.position = new Vector3(11.1f,0.7f,0.0f);
            clearTable();
        }
        else if(itemsOnBench[0].tag == "PackGas"){
            GameObject jetpack = GameObject.Find("packPrefab");
            GameObject jetpack1 = Instantiate(jetpack);
            GameObject jetpack2 = Instantiate(jetpack);
            jetpack1.transform.position = new Vector3(1.92f,-1.41f,0.0f);
            jetpack2.transform.position = new Vector3(10.36f,-1.41f,0.0f);
            clearTable();
        }
        else if(itemsOnBench[0].tag == "SuitThread"){
            GameObject suit = GameObject.Find("suitPrefab");
            GameObject suit1 = Instantiate(suit);
            GameObject suit2 = Instantiate(suit);
            suit1.transform.position = new Vector3(2.52f,-1.41f,0.0f);
            suit2.transform.position = new Vector3(10.98f,-1.41f,0.0f);
            clearTable();
        }
        else if(itemsOnBench[0].tag == "BootsBrush"){
            GameObject boots = GameObject.Find("bootsPrefab");
            GameObject boots1 = Instantiate(boots);
            GameObject boots2 = Instantiate(boots);
            boots1.transform.position = new Vector3(2.28f,-0.25f,0.0f);
            boots2.transform.position = new Vector3(10.36f,-0.25f,0.0f);
            clearTable();
        }
    }

    // Update is called once per frame
    void Update()
    {
         if(numberOfItemsOnBench == 2){
            if (itemsOnBench[0].tag == itemsOnBench[1].tag) {
                moveToStand();
                
        } else {
            resetTable();
        }
        }
    }
}

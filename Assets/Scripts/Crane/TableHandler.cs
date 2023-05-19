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

    public LevelLoader lvlLoader;
    int counter = 0;

    public GameObject smoke; 
    [SerializeField] private AudioSource correct;
    [SerializeField] private AudioSource fail;

    // Start is called before the first frame update
    void Start()
    {
        smoke.SetActive(false);
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
            helm1.transform.position = new Vector3(2.64f,0.7f,0.0f);
            helm2.transform.position = new Vector3(11.0f,0.7f,0.0f);
            clearTable();
        }
        else if(itemsOnBench[0].tag == "PackGas"){
            GameObject jetpack = GameObject.Find("packPrefab");
            GameObject jetpack1 = Instantiate(jetpack);
            GameObject jetpack2 = Instantiate(jetpack);
            jetpack1.transform.position = new Vector3(2.13f,-0.613f,0.0f);
            jetpack2.transform.position = new Vector3(10.48f,-0.65f,0.0f);
            clearTable();
        }
        else if(itemsOnBench[0].tag == "SuitThread"){
            GameObject suit = GameObject.Find("suitPrefab");
            GameObject suit1 = Instantiate(suit);
            GameObject suit2 = Instantiate(suit);
            suit1.transform.position = new Vector3(2.54f,-1.4f,0.0f);
            suit2.transform.position = new Vector3(10.94f,-1.4f,0.0f);
            clearTable();
        }
        else if(itemsOnBench[0].tag == "BootsBrush"){
            GameObject boots = GameObject.Find("bootsPrefab");
            GameObject boots1 = Instantiate(boots);
            GameObject boots2 = Instantiate(boots);
            boots1.transform.position = new Vector3(1.17f,-3.14f,0.0f);
            boots2.transform.position = new Vector3(12.32f,-3.26f,0.0f);
            clearTable();
        }
    }

    IEnumerator checkItems(){
        smoke.SetActive(true);
        numberOfItemsOnBench = 0;
        yield return new WaitForSeconds(2);
        if (itemsOnBench[0].tag == itemsOnBench[1].tag) {
            moveToStand();
            correct.Play();
            counter+=1;  
        } 
        else if(itemsOnBench[0].tag != itemsOnBench[1].tag){
            resetTable();
            fail.Play();
        }
        yield return new WaitForSeconds(1);
        smoke.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(numberOfItemsOnBench == 2){
            StartCoroutine(checkItems()); 
        }

        if (counter==4){
            lvlLoader.LoadNextLevel("OrbitPuzzle");
        }
    }
}

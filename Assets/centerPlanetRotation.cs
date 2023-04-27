using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

<<<<<<<< HEAD:Assets/Scripts/TextScore.cs
public class TextScore : MonoBehaviour
{
    public TMP_Text hitsText;
========
public class PlanetRotation : MonoBehaviour
{
    public float rotationSpeed = 2f;
    public GameObject Planet;
>>>>>>>> planetPusselTest:Assets/centerPlanetRotation.cs

    // Start is called before the first frame update
    void Start()
    {
        hitsText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<<< HEAD:Assets/Scripts/TextScore.cs
        hitsText.text = "Antal nuddar: " + Score.numberOfHits.ToString();
========
        Planet.transform.rotation *= Quaternion.Euler(0f, 0f, rotationSpeed * Time.deltaTime);
>>>>>>>> planetPusselTest:Assets/centerPlanetRotation.cs
    }
}
